$(document).ready(function(){
	//ShowVideo();

$("#btnallco").click(function(){
	LoadAllCourses();
	

});
$("#btnmyco").click(function(){
	LoadMyCourses();

});

$("#btnreg").click(function(){
	MyRegInfo();

});





function LoadAllCourses()
{
	$.ajax({
			url:"http://localhost:61115/api/subjects",
			method:"get",
			complete:function(xmlHttp,status){
				if(xmlHttp.status==200)
				{
					$("#no").html(" ");
					var data=xmlHttp.responseJSON;
					var str='';
					str+="<tr><td>"+"Subject Id"+"</td><td>"+"Subject Name"+"</td><td>"+"Subject Type"+"</td><td>"+" Description"+"</td><td>"+"Total Students"+"</td><td>"+"Price"+"</td><td>"+"</td></tr>";
					for (var i = 0; i < data.length; i++) {
						str+="<tr><td>"+data[i].subjectId+"</td> <td>"+data[i].subjectName+"</td> <td>"+data[i].subjectType+"</td> <td>"+data[i].description+"</td> <td>"+data[i].studentCount+"</td> <td>"+data[i].price+"</td></tr>";
						$("#showallcos").html(str);
					};
					
				}
				else
				{

					console.log(xmlHttp.status+":"+xmlHttp.statusText);
				}
			}
	});
}

function LoadMyCourses()
{
	var Username=localStorage.Username;
	var Password=localStorage.Password; 
	$.ajax({
			url:"http://localhost:61115/api/students/mycourses",
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
					str+="<tr><td>"+"Subject Name"+"</td><td>"+"Teacher Id"+"</td></tr>";
					for (var i = 0; i < data.length; i++) {
						str+="<tr><td>"+data[i].courseName+"</td> <td>"+data[i].teacherId+"</td> </tr>";
						$("#showallcos").html(str);
					};
					
				}
				else
				{	$("#no").html("No content");
					console.log(xmlHttp.status+":"+xmlHttp.statusText);
				}
			}
	});
}

function MyRegInfo()
{
	var Username=localStorage.Username;
	var Password=localStorage.Password; 
	$.ajax({
			url:"http://localhost:61115/api/students/registration",
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
					var total=0;
					str+="<tr><td>"+"Reg Id"+"</td><td>"+"Subject Id"+"</td><td>"+"Fee"+"</td></tr>";
					for (var i = 0; i < data.length; i++) {
						str+="<tr><td>"+data[i].regId+"</td> <td>"+data[i].subjectId+"</td> <td>"+data[i].fee+"</td>  </tr>";
						$("#showallcos").html(str);
					};

					for(var x=0; x < data.length; x++)
					{
						total+=data[x].fee;
					};
					$("#showtotal").html("Total: "+total);
					
				}
				else
				{	$("#no").html("No content");
					console.log(xmlHttp.status+":"+xmlHttp.statusText);
				}
			}
	});
}

/*function ShowVideo()
{
	var Username=localStorage.Username;
	var Password=localStorage.Password; 
	var id=13;
	$.ajax({
			url:"http://localhost:61115/api/students/subjects/"+id+"/videos",
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
					
					//var th='';
					//th+="<tr><th>ID</td><th>CourseName</td><th>Type```````</td><th>Description</td></tr>";
					//$("#head").html(th);
					for (var i = 0; i < data.length; i++) {
						str+="<p>"+data[i].videoName+"</p> <p>"+data[i].videoDescription+"</p>";
						//$("#vid").html(str);
					};

				}
				else
				{	$("#no").html("No content");
					console.log(xmlHttp.status+":"+xmlHttp.statusText);
				}
			}
	});
}
*/
});