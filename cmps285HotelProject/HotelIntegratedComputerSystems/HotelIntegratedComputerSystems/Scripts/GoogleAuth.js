
function onSignIn(googleUser) {

    var auth2 = gapi.auth2.getAuthInstance();
    var profile = googleUser.getBasicProfile();
    var googleEmail = profile.getEmail();

    if (auth2.isSignedIn.get()) {
        confirm("This code ran");

        $.ajax({
            type: "POST",
            url: '/GoogleLoginViewModels/LogIn',
            data: JSON.stringify({ googleEmail }),
            dataType: 'text',
            contentType: "application/json; charset=utf-8"
        });
    }
    else {
        confirm("you are not a user in HICS");
    }
}

function signOut() {
    var auth2 = gapi.auth2.getAuthInstance();

    //	log out of google
    var scriptTag = document.createElement("script");
    scriptTag.src = "https://mail.google.com/mail/u/0/?logout&hl=en";
    document.head.appendChild(scriptTag);

    //	let us actually log out of the application now
    auth2.disconnect();
    auth2.signOut().then(function () {
        console.log("User logged out.");
    });
}