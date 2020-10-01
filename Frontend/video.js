$(document).ready(function(){


ComboSelectLoadMyCourses();

$("#CourseSelect").change(function(){
		split=$("#CourseSelect").val().split("--");
		$("#GetCourseContent").val(split[1]);
	});

$("#saveenroll").click(function(){
		if($("#GetCourseContent").val()=="")
		{
			alert("Select a Course First!");
		}
		else
		{
			ShowVideo();
		}
		
	});

function ComboSelectLoadMyCourses()
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
				
					for (var i = 0; i < data.length; i++) {
						str+="<option>"+data[i].courseId+"--"+data[i].courseName+"</option>";
						
						
						$("#CourseSelect").html(str);
						
					};
					
				}
				else
				{
					console.log(xmlHttp.status+":"+xmlHttp.statusText);
				}
			}	

		});
}

function ShowVideo()
{
	var Username=localStorage.Username;
	var Password=localStorage.Password; 
	var id=split[0];
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
					
					
					for (var i = 0; i < data.length; i++) {
						str+="<p>"+data[i].videoName+"</p> <p>"+data[i].videoDescription+"</p>";
						
						str+="<video width='520' height='480' controls><source src='FinalProject/FinalProject/Uploaded/Videos/"+data[i].videoName+"'></video><br>";

						$("#myid").html(str);
					};

				}
				else
				{	$("#no").html("No content");
					console.log(xmlHttp.status+":"+xmlHttp.statusText);
				}
			}
	});
}


});