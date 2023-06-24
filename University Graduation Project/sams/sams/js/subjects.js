function readSubjects(){
    // Reading Subjects information to the table
    firebase.firestore().collection("subjects").onSnapshot(function(sanpshot){

        document.getElementById("subjects-table").innerHTML="";
        sanpshot.forEach(function(subjectValue){
            document.getElementById("subjects-table").innerHTML+=`
            <tr>
                <td>${subjectValue.data().name}</td>
                <td>${subjectValue.data().teacher}</td>
                <td>${subjectValue.data().year}</td>
                <td>
                    <button type="button" class="btn btn-success" onclick="editSubject(
                        '${subjectValue.id}',
                        '${subjectValue.data().name}',
                        '${subjectValue.data().teacher}',
                        '${subjectValue.data().year}'
                    );"> تعديل <i class="fas fa-edit"></i></button>
                    <button type="button" class="btn btn-danger" onclick="areYouSureDelete('${subjectValue.id}');"> حذف <i class="fas fa-trash-alt"></i></button>
                    <button onclick="addStudent();" type="button" class="btn btn-primary"> إضافة طالب <i class="fas fa-plus"></i>  </button>
                </td>
            </tr>
            
        `})
        
    });

    // Reading Subject's teachers to the form select box for adding new subjects
    firebase.firestore().collection("teachers").onSnapshot(function(sanpshot){
        sanpshot.forEach(function(teacherValue){
            document.getElementById("subject-teacher").innerHTML+=`
                <option value="${teacherValue.data().name}">${teacherValue.data().name}</option>
        `})      
    });

}



function readSublectsInSpecificYear(){
    var year = document.getElementById("table-subjects-year-filter").value;
    if(year == 'none'){

        readSubjects();

    }
    else{

    firebase.firestore().collection("subjects").where("year", "==", year).onSnapshot(function(sanpshot){

        document.getElementById("subjects-table").innerHTML="";
        sanpshot.forEach(function(subjectValue){
            document.getElementById("subjects-table").innerHTML+=`
            <tr>
                <td>${subjectValue.data().name}</td>
                <td>${subjectValue.data().teacher}</td>
                <td>${subjectValue.data().year}</td>
                <td>
                    <button type="button" class="btn btn-success" onclick="editSubject(
                        '${subjectValue.id}',
                        '${subjectValue.data().name}',
                        '${subjectValue.data().teacher}',
                        '${subjectValue.data().year}'
                    );"> تعديل <i class="fas fa-edit"></i></button>
                    <button type="button" class="btn btn-danger" onclick="areYouSureDelete('${subjectValue.id}');"> حذف <i class="fas fa-trash-alt"></i></button>
                    <button onclick="addStudent();" type="button" class="btn btn-primary"> إضافة طالب <i class="fas fa-plus"></i>  </button>
                </td>
            </tr>
            
        `})
        
    });

    // Reading Subject's teachers to the form select box for adding new subjects
    firebase.firestore().collection("teachers").onSnapshot(function(sanpshot){
        sanpshot.forEach(function(teacherValue){
            document.getElementById("subject-teacher").innerHTML+=`
                <option value="${teacherValue.data().name}">${teacherValue.data().name}</option>
        `})      
    });



    }
}



function addSubject(){
    var subject = {
        name: document.getElementById("subject-name").value,
        teacher: document.getElementById("subject-teacher").value,
        year: document.getElementById("subject-year").value
    }
    firebase.firestore().collection("subjects").doc(document.getElementById("subject-name").value).set(subject).then(() => {
        console.log("Student successfully added!");
        document.getElementById("subject-name").value="";
        document.getElementById("subject-teacher").value="";
        document.getElementById("subject-year").value="";
    }).catch((error) => {
        console.error("Error adding student: ", error);
    });
}



function areYouSureDelete(id){
    swal({
        title: "هل أنت متأكد؟",
        text: "بمجرد حذف البيانات لن تكون قادر على استعادتها",
        icon: "warning",
        buttons: true,
        dangerMode: true,
      })
      .then((willDelete) => {
        if (willDelete) {
          deleteSubject(id);
        } else {
            swal({
                text: "تم إالغاء عملية الحذف",
                timer: 1500,
                button: false
            });  
        }
      });
}



function deleteSubject(id){
    firebase.firestore().collection("subjects").doc(id).delete().then(() => {
        swal({
            title: "حذف مادة",
            text: "تم حذف مادة بنجاح!",
            icon: "success",
            timer: 1500,
            button: false
        });
    }).catch((error) => {
        console.error("Error removing subject: ", error);
    });
    
}







function editSubject(id, name, teacher, year){
    document.getElementById("edit-section").innerHTML=`
    <h1> تعديل معلومات `+name+`</h1>
    <br>
    <form style="background-color:#343a40; transition: 1s;
    padding:50px">
    <div class="form-row">
      <input type="hidden" id="subject-id" value="`+id+`">
      <div class="col-4">
        <input id="subject-new-name" type="text" class="form-control" placeholder="اسم المادة" value="`+name+`">
      </div>
      <div class="col-3">
      <select id="subject-new-teacher" class="form-control">
        <option value="none">اختر محاضراً</option>
      </select> 
      </div>
      <div class="col-3">
        <select id="subject-new-year" class="form-control">
            <option value="none">السنة الدراسية</option>
            <option value="الاولى">السنة الاولى</option>
            <option value="الثانية">السنة الثانية</option>
            <option value="الثالثة">السنة الثالثة</option>
            <option value="الرابعة">السنة الرابعة</option>
            <option value="الخامسة">السنة الخامسة</option>
        </select>
      </div>
      <div class="col-2">
        <button onclick="updateSubject(); return false;" type="button" class="btn btn-primary">تحديث المعلومات</button>
      </div>
    </div>
  </form>
  <br>
  <hr>
    `;
    // Reading Subject's teachers to the form select box for editinf existing subjects
    firebase.firestore().collection("teachers").onSnapshot(function(sanpshot){
        sanpshot.forEach(function(teacherValue){
            document.getElementById("subject-new-teacher").innerHTML+=`
                <option value="${teacherValue.data().name}">${teacherValue.data().name}</option>
        `});      
    });
    window.scrollTo({
        top: 0,
        left: 0,
        behavior: 'smooth'
      });
}

function updateSubject(){
    var id = document.getElementById("subject-id").value;
    var name = document.getElementById("subject-new-name").value;
    var teacher = document.getElementById("subject-new-teacher").value;
    var year = document.getElementById("subject-new-year").value;

    firebase.firestore().collection("subjects").doc(id).update({
        name: name,
        teacher: teacher,
        year: year
    }).then(() => {
        swal({
            title: "تعديل مادة",
            text: "تم تحديث معلومات المادة",
            icon: "success",
            timer: 1500,
            button: false
        });
        console.log("Subject successfully updated!");
        document.getElementById("edit-section").innerHTML="";
    }).catch((error) => {
        console.error("Error updating Subject: ", error);
    });

}
