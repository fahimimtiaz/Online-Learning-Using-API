$(document).ready(function(){

$("#btnAllCourse").click(function(){
	LoadAllCourses();

});

$("#btnMyProfile").click(function(){
	LoadMyProfile();

});
$("#btnMyCourse").click(function(){
	LoadMyCourses();

});


function LoadMyCourses()
{
	var Username=localStorage.Username;
	var Password=localStorage.Password;

	$.ajax({
			url:"http://localhost:61115/api/Teachers/Subjects",
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
					str+="<tr><td>"+"Subject Id"+"</td><td>"+"Subject Name"+"</td><td>"+"Subject Type"+"</td><td>"+" Description"+"</td><td>"+"Total Students"+"</td><td>"+"Price"+"</td><td>"+"</td></tr>";					
					for (var i = 0; i < data.length; i++) {
						str+="<tr><td>"+data[i].subjectId+"</td> <td>"+data[i].subjectName+"</td> <td>"+data[i].subjectType+"</td> <td>"+data[i].description+"</td> <td>"+data[i].studentCount+"</td> <td>"+data[i].price+"</td></tr>";
						$("#GlobalTable").html(str);
					};
					
				}
				else
				{

					console.log(xmlHttp.status+":"+xmlHttp.statusText);
				}
			}
	});
}





function LoadAllCourses()
{
	var Username=localStorage.Username;
	var Password=localStorage.Password;
	$.ajax({
			url:"http://localhost:61115/api/Subjects",
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
					str+="<tr><td>"+"Subject Id"+"</td><td>"+"Subject Name"+"</td><td>"+"Subject Type"+"</td><td>"+" Description"+"</td><td>"+"Total Students"+"</td><td>"+"Price"+"</td><td>"+"</td></tr>";					
					for (var i = 0; i < data.length; i++) {
						str+="<tr><td>"+data[i].subjectId+"</td> <td>"+data[i].subjectName+"</td> <td>"+data[i].subjectType+"</td> <td>"+data[i].description+"</td> <td>"+data[i].studentCount+"</td>";
						$("#GlobalTable").html(str);
					};
					
				}
				else
				{

					console.log(xmlHttp.status+":"+xmlHttp.statusText);
				}
			}
	});
}

});
