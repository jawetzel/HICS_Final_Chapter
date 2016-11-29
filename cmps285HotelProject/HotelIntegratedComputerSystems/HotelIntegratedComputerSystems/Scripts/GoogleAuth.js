function onSignIn(googleUser) {

    var auth2 = gapi.auth2.getAuthInstance();
    var profile = googleUser.getBasicProfile();
    var googleEmail = profile.getEmail();

    if (auth2.isSignedIn.get()) {
        $.ajax({
            type: "POST",
            url: '/Home/LogIn',
            data: JSON.stringify({ googleEmail }),
            dataType: 'json',
            contentType: "application/json; charset=utf-8",
            success: function (response){
                if(response.isUser){
                    sendToHomePage(response.typeId);
                }
           }
        });
    }
}

function signOut() {

    try {
        //	let us actually log out of the application now
        var auth2 = gapi.auth2.getAuthInstance();
        auth2.disconnect();
        auth2.asignOut();
    }
    //	let us actually log out of the application now
    catch (e) {
        console.log(e.message, e.name); // pass exception object to err handler
    }

    //	log out of google
    var scriptTag = document.createElement("script");
    scriptTag.src = "https://mail.google.com/mail/u/0/?logout&hl=en";
    document.head.appendChild(scriptTag);

    //  log the user out(backend)
    $.ajax({
        type: "POST",
        url: '/Home/LogOut',
        contentType: "application/json; charset=utf-8",
        success: function () {
            window.open("~/Home", "_self");
        }
    });
}

function sendToHomePage(typeId) {
    if (typeId == 1) {
        window.open("/HouseKeeping/Index", "_self");
    }
    else if(typeId == 2){
        window.open("/HouseKeeping/Index", "_self");
    }
    else if (typeId == 3) {
        window.open("/GridView/Index", "_self");
    }
    else if (typeId >= 4) {
        //window.location.href = "/GridView/Index";
        window.open("/GridView/Index", "_self");
    }
}