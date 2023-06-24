
// This function selects the subjects depending on the selected year and display them as select list
function selectSubjects(){
    var year = document.getElementById("subject-year").value;
    var subject = document.getElementById("subject-per-year");
    subject.innerHTML='<option value="none">المادة</option>';
    firebase.firestore().collection("subjects").where("year", "==", year).onSnapshot(function(sanpshot){
        sanpshot.forEach(function(subjectValue){
            console.log(subjectValue.data().name);
            subject.innerHTML+=`<option value="${subjectValue.data().name}">${subjectValue.data().name}</option>`;
            })      
    });
}

// This function selects students added to certain subject dependin on the selected subject and displays them in the added students section
function selectAddedStudents(){
    var addedStudentContainer = document.getElementById("added-students-container");
    var subject = document.getElementById("subject-per-year").value;
    addedStudentContainer.innerHTML="";
    firebase.firestore().collection("/subjects/" + subject + "/students").onSnapshot(function(sanpshot){
        sanpshot.forEach(function(studentValue){
            console.log(studentValue.data.name);
            addedStudentContainer.innerHTML+=`<div class="form-check col-md-3">
                                                <input type="checkbox" class="form-check-input" name="${studentValue.data().year}" id="${studentValue.data().number}" value="${studentValue.data().name}">
                                                <label class="form-check-label" for="${studentValue.data().number}">${studentValue.data().name}</label>
                                            </div>`;
        })      
    });
}


// This function selects all students and display them in the all students section
function selectAllStudents(){
    var allStudentsContainer = document.getElementById("all-students-container");
    var year = document.getElementById("year-filter").value;
    allStudentsContainer.innerHTML="";
    firebase.firestore().collection("students").where("year", "==", year).onSnapshot(function(sanpshot){
        sanpshot.forEach(function(studentValue){
            console.log(studentValue.data().name);
            allStudentsContainer.innerHTML+=`<div class="form-check col-md-3">
                                                <input type="checkbox" class="form-check-input" name="${studentValue.data().year}" id="${studentValue.data().number}" value="${studentValue.data().name}">
                                                <label class="form-check-label" for="${studentValue.data().number}">${studentValue.data().name}</label>
                                            </div>`;
         })      
    });
}




// This function adds checked students to the slected subject
function addToStudentList() {  
  var subject = document.getElementById("subject-per-year").value; 
  var markedCheckbox = document.querySelectorAll('#all-students-container input[type="checkbox"]:checked'); 
  for (var checkbox of markedCheckbox) {  
        var student = {
        name: checkbox.value,
        number: checkbox.id,
        year: checkbox.getAttribute('name')
    }
    firebase.firestore().collection("/subjects/"+ subject +"/students").doc(checkbox.id).set(student).then(() => {
        swal({
            title: " إضافة طلاب",
            text: "تمت إضافة الطالاب",
            icon: "success",
            timer: 1500,
            button: false
        });       
        selectAddedStudents();
    }).catch((error) => {
        console.error("Error adding student: ", error);
    });
  }  
}  

// This function makes sure that the user will delete the checked students
function areYouSureDelete(){
    swal({
        title: "هل أنت متأكد؟",
        text: "بمجرد حذف البيانات لن تكون قادر على استعادتها",
        icon: "warning",
        buttons: true,
        dangerMode: true,
      })
      .then((willDelete) => {
        if (willDelete) {
            deleteFromStudentsList();
        } else {
            swal({
                text: "تم إالغاء عملية الحذف",
                timer: 1500,
                button: false
            });  
        }
      });
}

// This function deletes the checked students from the selected subject
function deleteFromStudentsList() {  
    var subject = document.getElementById("subject-per-year").value;
    var markedNotCheckbox = document.querySelectorAll('#added-students-container input[type="checkbox"]:checked'); 
    for (var checkbox of markedNotCheckbox) {  
      firebase.firestore().collection("/subjects/"+ subject +"/students").doc(checkbox.id).delete().then(() => {
        swal({
            title: "حذف الطلاب",
            text: "تم حذف الطلاب بنجاح!",
            icon: "success",
            timer: 1500,
            button: false
        });
        selectAddedStudents();
      }).catch((error) => {
          console.error("Error deleting students: ", error);
      });
  
      window.relo
    }  
  }  