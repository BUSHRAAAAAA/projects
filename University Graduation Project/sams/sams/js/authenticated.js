firebase.auth().onAuthStateChanged(function(user) {
    if (user) {
      // User is signed in.
      console.log("welcome!");
    } else {
      // No user is signed in.
      location.href = 'sign-in.html';
    }
});

