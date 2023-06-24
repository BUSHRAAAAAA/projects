function readStudents(){
    firebase.firestore().collection("students").onSnapshot(function(sanpshot){

        document.getElementById("students-table").innerHTML="";
        sanpshot.forEach(function(studentValue){
            document.getElementById("students-table").innerHTML+=`
            <tr>
                <td>${studentValue.data().name}</td>
                <td>${studentValue.data().number}</td>
                <td>${studentValue.data().year}</td>
                <td>
                    <button type="button" class="btn btn-success" onclick="editStudent(
                        '${studentValue.id}',
                        '${studentValue.data().name}',
                        '${studentValue.data().number}',
                        '${studentValue.data().year}'
                    );"> تعديل <i class="fas fa-edit"></i></button>
                    <button type="button" class="btn btn-danger" onclick="areYouSureDelete('${studentValue.id}');"> حذف <i class="fas fa-trash-alt"></i></button>
                </td>
            </tr>
            
        `})
        
    });
}


function readStudentsInSpecificYear(){
    var year = document.getElementById("table-student-year-filter").value;
    if(year == 'none'){

        readStudents();

    }
    else{

        firebase.firestore().collection("students").where("year", "==", year).onSnapshot(function(sanpshot){

            document.getElementById("students-table").innerHTML="";
            sanpshot.forEach(function(studentValue){
                document.getElementById("students-table").innerHTML+=`
                <tr>
                    <td>${studentValue.data().name}</td>
                    <td>${studentValue.data().number}</td>
                    <td>${studentValue.data().year}</td>
                    <td>
                        <button type="button" class="btn btn-success" onclick="editStudent(
                            '${studentValue.id}',
                            '${studentValue.data().name}',
                            '${studentValue.data().number}',
                            '${studentValue.data().year}'
                        );"> تعديل <i class="fas fa-edit"></i></button>
                        <button type="button" class="btn btn-danger" onclick="areYouSureDelete('${studentValue.id}');"> حذف <i class="fas fa-trash-alt"></i></button>
                    </td>
                </tr>
                
            `})
            
        });
    
    }
    
}


function addStudent(){
    var student = {
        name: document.getElementById("student-name").value,
        number: document.getElementById("student-number").value,
        year: document.getElementById("student-year").value
    }
    firebase.firestore().collection("students").doc(document.getElementById("student-number").value).set(student).then(() => {
        console.log("Student successfully added!");
        document.getElementById("student-name").value="";
        document.getElementById("student-number").value="";
        document.getElementById("student-year").value="";
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
          deleteStudent(id);
        } else {
            swal({
                text: "تم إالغاء عملية الحذف",
                timer: 1500,
                button: false
            });  
        }
      });
}



function deleteStudent(id){
    firebase.firestore().collection("students").doc(id).delete().then(() => {
        swal({
            title: "حذف طالب",
            text: "تم حذف طالب بنجاح!",
            icon: "success",
            timer: 1500,
            button: false
        });
    }).catch((error) => {
        console.error("Error removing Student: ", error);
    });
    
}







function editStudent(id, name, number, year){
    document.getElementById("edit-section").innerHTML=`
    <h1> تعديل معلومات `+name+`</h1>
    <br>
    <form style="background-color:#343a40; transition: 1s;
    padding:50px">
    <div class="form-row">
      <input type="hidden" id="student-id" value="`+id+`">
      <div class="col-4">
        <input id="student-new-name" type="text" class="form-control" placeholder="اسم المدرس" value="`+name+`">
      </div>
      <div class="col-3">
        <input id="student-new-number" type="number" class="form-control" placeholder="اسم المستخدم" value="`+number+`">
      </div>
      <div class="col-3">
        <select id="student-new-year" class="form-control">
            <option value="none">السنة الدراسية</option>
            <option value="الاولى">السنة الاولى</option>
            <option value="الثانية">السنة الثانية</option>
            <option value="الثالثة">السنة الثالثة</option>
            <option value="الرابعة">السنة الرابعة</option>
            <option value="الخامسة">السنة الخامسة</option>
        </select>
      </div>
      <div class="col-2">
        <button onclick="updateStudent(); return false;" type="button" class="btn btn-primary">تحديث المعلومات</button>
      </div>
    </div>
  </form>
  <br>
  <hr>
    `;
    window.scrollTo({
        top: 0,
        left: 0,
        behavior: 'smooth'
      });
}

function updateStudent(){
    var id = document.getElementById("student-id").value;
    var name = document.getElementById("student-new-name").value;
    var number = document.getElementById("student-new-number").value;
    var year = document.getElementById("student-new-year").value;

    firebase.firestore().collection("students").doc(id).update({
        name: name,
        number: number,
        year: year
    }).then(() => {
        swal({
            title: "تعديل طالب",
            text: "تم تحديث معلومات الطالب",
            icon: "success",
            timer: 1500,
            button: false
        });
        document.getElementById("edit-section").innerHTML="";
    }).catch((error) => {
        console.error("Error updating Teacher: ", error);
    });

}




