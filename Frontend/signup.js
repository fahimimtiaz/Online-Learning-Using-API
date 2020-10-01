$(document).ready(function(){

$("#btnSign").click(function(){

    SignUp();

});

function SignUp()
{
	$.ajax({

		url:"http://localhost:61115/api/SignUp",
                method:"Post",
                headers:{
                    contentType:"application/json"
					
                },
                data:{
                	
                	userName:$("#Username").val(),
                	email:$("#Useremail").val(),
                	password:$("#Userpassword").val(),
                	userType:$("#Usertype").val(),
                	
                },

                complete:function(xmlHttp,status)
                {
                	if(xmlHttp.status==200)
                	{
                		alert("Done!");
                		$(location).attr('href', "login.html");
                	}
                }
	});
}

});