$(document).ready(function(){

MyMessages();

$("#btnSendMsg").click(function(){
	SendMessage();
	
});

function MyMessages()
{
	var Username=localStorage.Username;
	var Password=localStorage.Password; 
	$.ajax({
			url:"http://localhost:61115/api/AdminHome/GetMyMsgs",
			method:"get",
			headers:{
				contentType:"application/json",
				Authorization: "Basic " +btoa(Username+":"+Password)
       			},
			complete:function(xmlHttp,status){
				if(xmlHttp.status==200)
				{
					var data=xmlHttp.responseJSON;
					var str='';
					str+="<tr><td>"+"Message"+"</td><td>"+"Sender Name"+"</td><td>"+"Receiver Name"+"</td></tr>";
					for (var i = 0; i < data.length; i++) {
						str+="<tr><td>"+data[i].text+"</td> <td>"+data[i].senderName+"</td> <td>"+data[i].receiverName+"</td> </tr>";
						$("#head").html(str);
					};
					
				}
				else
				{	//$("#no").html("No content");
					console.log(xmlHttp.status+":"+xmlHttp.statusText);
				}
			}
	});
}

function SendMessage()
{
	var Username=localStorage.Username;
	var Password=localStorage.Password; 

	$.ajax({
			url:"http://localhost:61115/api/AdminHome/sendMsgs",
			method:"post",
			headers:{
				contentType:"application/json",
				Authorization: "Basic " +btoa(Username+":"+Password)
			},
			data:{
				receiverName:$("#rcvName").val(),
				text:$("#theText").val()
				
			},
			complete:function(xmlHttp,status){
				if(xmlHttp.status==200)
				{
					alert("Successful!");
					$("#rcvName").val("");
					$("#theText").val("");
					MyMessages();
					

				}
				else
				{
					$("#enrollMsg").html("Error");
					console.log(xmlHttp.status+":"+xmlHttp.statusText);
				}
			}
		});
}

});
