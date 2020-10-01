$(document).ready(function(){

	$("#btnlogin").click(function(){
		localStorage.Username = $("#Username").val();
		localStorage.Password = $("#Password").val();
		Validate();
	});

function Validate()
{
	$.ajax({
			url:"http://localhost:61115/api/logins/validate",
			method:"post",
			headers:{
				contentType:"application/json"//,
				//Authorization: "Basic "+btoa($("#userid").val()+":"+$("#password").val())
       			},
			data:{	
				userName:$("#Username").val(),
				password:$("#Password").val()
        		},
			complete:function(xmlHttp,status)
			{
				if(xmlHttp.status==200)
				{
					var data=xmlHttp.responseJSON;
					if(data=="Student")
					{
						$(location).attr('href', "studentDash.html");
					}
					else if(data=="Teacher")
					{
						$(location).attr('href', "TeacherDash.html");
					}
					else if(data=="Admin")
					{
						$(location).attr('href', "AdminDash.html");
					}
					else
					{
						$(location).attr('href', "test.html");
					}
					
						
				
				}
				else
				{
					$("#message").html("Invalid Credentials");
                	console.log(xmlHttp.status+":"+xmlHttp.statusText);

				}
				
			}

	});
}


});