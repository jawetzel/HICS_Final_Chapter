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
                    sendToHomePage(response.accessLevel);
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
            window.open("/Home/Index", "_self");
        }
    });
}

function sendToHomePage(accessLevel) {
    if (accessLevel == 1) {
        window.open("/HouseKeeping/Index", "_self");
    }
    else if (accessLevel == 2) {
        window.open("/MaintenanceLogs/Index", "_self");
    }
    else if (accessLevel >= 3) {
        window.open("/GridView/Index", "_self");
    }
}