$(document).ready(function(){


	LoadMyProfile();




function LoadMyProfile()
{
	var Username=localStorage.Username;
	var Password=localStorage.Password;

	$.ajax({
			url:"http://localhost:61115/api/Teachers/OwnProfile",
			method:"get",
			headers:{
                    contentType:"application/json",
					Authorization: "Basic " +btoa(Username+":"+Password)
                },

			complete:function(xmlHttp,status){
				if(xmlHttp.status==200)
				{
					$("#no").html(" ");
					var data=xmlHttp.responseJSON;
					var str='';


					for (var i = 0; i < data.length; i++) {

						$("#TeacherId").val(data[i].teacherId);
                		$("#TeacherName").val(data[i].teacherName);
                		$("#MobileNo").val(data[i].mobileNo);
                		$("#Address").val(data[i].address);
                		$("#Institute").val(data[i].institute);
                		$("#Salary").val(data[i].salary);
                		str+= "<img width='200' height='200' src='FinalProject/FinalProject/Uploaded/ProImage/"+data[i].imageName+"'>";
                		$("#ShowTeaImg2").html(str);

					};

					
				}
				else
				{
					$("#msg").val("Data not found");
					console.log(xmlHttp.status+":"+xmlHttp.statusText);
				}
			}
	});
}



}); 