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
    var auth2 = gapi.auth2.getAuthInstance()
    confirm("You are signing out?");

    //  log the user out(backend)
    $.ajax({
        type: "POST",
        url: '/Home/LogOut',
        contentType: "application/json; charset=utf-8"
    });

    //	log out of google
    var scriptTag = document.createElement("script");
    scriptTag.src = "https://mail.google.com/mail/u/0/?logout&hl=en";
    document.head.appendChild(scriptTag);

    //	let us actually log out of the application now
    auth2.disconnect();
    auth2.signOut().then(function () {
        console.log("User logged out.");
    });

    window.location.reload();
}

function sendToHomePage(typeId) {
    if (typeId == 1) {
        window.open("http://localhost:52703/HouseKeeping", "_self");
    }
    else if(typeId == 2){
        window.open("http://localhost:52703/HouseKeeping", "_self");
    }
    else if (typeId == 3) {
        window.open("http://localhost:52703/HouseKeeping", "_self");
    }
    else if (typeId >= 4) {
        window.open("http://localhost:52703/Employees", "_self");
    }
}