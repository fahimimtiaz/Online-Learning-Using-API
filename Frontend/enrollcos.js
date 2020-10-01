$(document).ready(function(){

ComboSelectLoadCourses();

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
			Enroll();
		}
		
	});

function ComboSelectLoadCourses()
{
	$.ajax({
			url:"http://localhost:61115/api/subjects",
			method:"get",
			complete:function(xmlHttp,status){
				if(xmlHttp.status==200)
				{
					var data=xmlHttp.responseJSON;
					var str='';
				
					for (var i = 0; i < data.length; i++) {
						str+="<option>"+data[i].subjectId+"--"+data[i].subjectName+"</option>";
						
						
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

function Enroll()
{ 
	var Username=localStorage.Username;
	var Password=localStorage.Password; 
	var cId=split[0];

	$.ajax({
			url:"http://localhost:61115/api/students/enroll",
			method:"post",
			headers:{
				contentType:"application/json",
				Authorization: "Basic " +btoa(Username+":"+Password)
			},
			data:{
				courseName:$("#GetCourseContent").val(),
				studentName:Username,
				courseId:cId
			},
			complete:function(xmlHttp,status){
				if(xmlHttp.status==200)
				{
					alert("Enrolled!");
					$("#GetCourseContent").val("");
					//$("#sucenrollMsg").html("Successfully Added");
					//LoadMyCourses();
					ComboSelectLoadComments();
					

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