// Log In Function
function logIn (){

    var email = document.getElementById("email").value;
    var password = document.getElementById("password").value;
    
    //Sign In User with Email and Password
    firebase.auth().signInWithEmailAndPassword(email, password).catch(function(error) {
        // Handle Errors here.
        var errorCode = error.code;
        var errorMessage = error.message;

        if (errorCode ==='auth/wrong-password'){
            swal({
                title: "خطأ",
                text: "كلمة المرور خاطئة، تأكد من كلمة المرور وأعد المحاولة",
                icon: "warning",
                timer: 1500,
                dangerMode: true,
              })
        }

        console.log(errorCode);
        console.log(errorMessage);

    });
    
}

// On Auth Change
firebase.auth().onAuthStateChanged(function(user) {
    if (user) {
        // User is signed in.
        location.href = 'index.html';
    }

});

  