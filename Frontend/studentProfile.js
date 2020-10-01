$(document).ready(function()
{
	LoadMyUserInfo();
    LoadMyUserInfoMore();

$("#btnUserSave").click(function(){

    UpdateStudent();
    UpdateStudentMore();

});

});

function LoadMyUserInfo()
{
	var Username=localStorage.Username;
	var Password=localStorage.Password;

	$.ajax({
		url:"http://localhost:61115/api/students/getUserInfo",
                method:"get",
                headers:{
                    contentType:"application/json",
					Authorization: "Basic " +btoa(Username+":"+Password)
                },
                complete:function(xmlHttp,status)
                {
                	if(xmlHttp.status==200)
                	{
                		var data=xmlHttp.responseJSON;

                		for (var i = 0; i < data.length; i++)
                		{

                			$("#Userid").val(data[i].userId);
                			$("#Username").val(data[i].userName);
                			$("#Useremail").val(data[i].email);
                			$("#Userpassword").val(data[i].password);
                			$("#Usertype").val(data[i].userType);
                			$("#Userstatus").val(data[i].status);
                			
                		}
                	
                	}
                	else
                    {
                    	$("#msg").val("Data not found");
                        console.log(xmlHttp.status+":"+xmlHttp.statusText);
                    }
                }
	});

} 

function UpdateStudent()
{
	var Username=localStorage.Username;
	var Password=localStorage.Password;

	$.ajax({
		url:"http://localhost:61115/api/students/updateUserInfo",
                method:"put",
                headers:{
                    contentType:"application/json",
					Authorization: "Basic " +btoa(Username+":"+Password)
                },
                data:{
                	userId:$("#Userid").val(),
                	userName:$("#Username").val(),
                	email:$("#Useremail").val(),
                	password:$("#Userpassword").val(),
                	userType:$("#Usertype").val(),
                	status:$("#Userstatus").val()
                },

                complete:function(xmlHttp,status)
                {
                	if(xmlHttp.status==200)
                	{
                		alert("Updated");
                		LoadMyUserInfo();

                	}
                	 else
                    {
                        $("#msg").html("Error");
                        console.log(xmlHttp.status+":"+xmlHttp.statusText);
                    }
                }

          });  
}
function LoadMyUserInfoMore() 
{
    var Username=localStorage.Username;
    var Password=localStorage.Password;

    $.ajax({
        url:"http://localhost:61115/api/OnlineStudents/getinfo",
                method:"get",
                headers:{
                    contentType:"application/json",
                    Authorization: "Basic " +btoa(Username+":"+Password)
                },
                complete:function(xmlHttp,status)
                {
                    if(xmlHttp.status==200)
                    {
                        var data=xmlHttp.responseJSON;
                        var str='';
                        for (var i = 0; i < data.length; i++)
                        {

                            $("#Stdid").val(data[i].studentId);
                            $("#Stdname").val(data[i].studentName);
                            $("#Stdmobile").val(data[i].mobileNo);
                            $("#StdIns").val(data[i].stdInstitute);
                            $("#StdUserId").val(data[i].userId);
                            $("#Stdadd").val(data[i].address);
                            //$("#StdImgName").val(data[i].imageName);
                            $("#StdImgPath").val(data[i].imagePath);
                            str+= "<img width='200' height='200' src='FinalProject/FinalProject/Uploaded/ProImage/"+data[i].imageName+"'>";
                            $("#ShowTeaImg2").html(str);
                        }
                    
                    }
                    else
                    {
                        $("#msg").val("Data not found");
                        console.log(xmlHttp.status+":"+xmlHttp.statusText);
                    }
                }
    });
}

