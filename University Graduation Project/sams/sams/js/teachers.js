function readTeachers(){
    firebase.firestore().collection("teachers").onSnapshot(function(sanpshot){

        document.getElementById("teacher-table").innerHTML="";
        sanpshot.forEach(function(teacherValue){
            document.getElementById("teacher-table").innerHTML+=`
            <tr>
                <td>${teacherValue.data().name}</td>
                <td>${teacherValue.data().username}</td>
                <td>${teacherValue.data().password}</td>
                <td>
                    <button type="button" class="btn btn-success" onclick="editTeacher(
                        '${teacherValue.id}',
                        '${teacherValue.data().name}',
                        '${teacherValue.data().username}',
                        '${teacherValue.data().password}'
                    );"> تعديل <i class="fas fa-edit"></i></button>
                    <button type="button" class="btn btn-danger" onclick="areYouSureDelete('${teacherValue.id}','${teacherValue.data().name}');"> حذف <i class="fas fa-trash-alt"></i></button>
                </td>
            </tr>
            
        `})
        
    });
}



function addTeacher(){
    var teacher = {
        name: document.getElementById("teacher-name").value,
        username: document.getElementById("teacher-username").value,
        password: document.getElementById("teacher-password").value
    }
    firebase.firestore().collection("teachers").doc(document.getElementById("teacher-name").value).set(teacher).then(() => {

        swal({
            title: "إضافة محاضر",
            text: "تمت إضافة المحاضر بنجاح",
            icon: "success",
            timer: 1500,
            button: false
        });

        console.log("Teacher successfully added!");
        document.getElementById("teacher-name").value="";
        document.getElementById("teacher-username").value="";
        document.getElementById("teacher-password").value="";
    }).catch((error) => {
        console.error("Error adding teacher: ", error);
    });
}


function areYouSureDelete(id,name){
    swal({
        title: "هل أنت متأكد؟",
        text: "بمجرد حذف البيانات لت تكون قادر على استعادتها",
        icon: "warning",
        buttons: true,
        dangerMode: true,
      })
      .then((willDelete) => {
        if (willDelete) {
          deleteTeacher(id,name);
        } else {
            swal({
                text: "تم إالغاء عملية الحذف",
                timer: 1500,
                button: false
            });  
        }
      });
}


function deleteTeacher(id,name){
    firebase.firestore().collection("teachers").doc(id).delete().then(() => {
        swal({
            title: "حذف محاضر",
            text: "تم حذف محاضر بنجاح!",
            icon: "success",
            timer: 1500,
            button: false
        });
    }).catch((error) => {
        console.error("Error removing Teacher: ", error);
    });
    //========================================================================
    /*
    var newVal = {
        teacher: "غير محدد"
    }
    firebase.firestore().collection("subjects").doc().where("teacher", "==", name).set(newVal);
    */
    //========================================================================
}

function editTeacher(id, name, username, password){
    document.getElementById("edit-section").innerHTML=`
    <h1> تعديل معلومات `+name+`</h1>
    <br>
    <form style="background-color:#343a40; transition: 1s;
    padding:50px">
    <div class="form-row">
      <input type="hidden" id="teacher-id" value="`+id+`">
      <div class="col-4">
        <input id="teacher-new-name" type="text" class="form-control" placeholder="اسم المدرس" value="`+name+`">
      </div>
      <div class="col-3">
        <input id="teacher-new-username" type="text" class="form-control" placeholder="اسم المستخدم" value="`+username+`">
      </div>
      <div class="col-3">
        <input id="teacher-new-password" type="text" class="form-control" placeholder="كلمة المرور" value="`+password+`">
      </div>
      <div class="col-2">
        <button onclick="updateTeacher(); return false;" type="button" class="btn btn-primary">تحديث المعلومات</button>
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

function updateTeacher(){
    var id = document.getElementById("teacher-id").value;
    var name = document.getElementById("teacher-new-name").value;
    var username = document.getElementById("teacher-new-username").value;
    var password = document.getElementById("teacher-new-password").value;

    firebase.firestore().collection("teachers").doc(id).update({
        name: name,
        username: username,
        password: password
    }).then(() => {
        swal({
            title: "تعديل محاضر",
            text: "تم تحديث معلومات المحاضر",
            icon: "success",
            timer: 1500,
            button: false
        });
        console.log("Teacher successfully updated!");
        document.getElementById("edit-section").innerHTML="";
    }).catch((error) => {
        console.error("Error updating Teacher: ", error);
    });

}

