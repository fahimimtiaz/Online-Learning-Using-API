$(document).ready(function(){

var total=0;
var stotal=0;
var profit=0;

$("#btnfin").click(function(){
	TeaFin();
	StdFin();

});
$("#btnUser").click(function(){
	AllUsers();

});
$("#btnTea").click(function(){
	AllTea();

});
$("#btnStd").click(function(){
	AllStd();

});
function TeaFin()
{
	var Username=localStorage.Username;
	var Password=localStorage.Password; 
	$.ajax({
			url:"http://localhost:61115/api/AdminHome/TeaFinancials",
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
					
					
					str+="<tr><td>"+"Teacher Id"+"</td><td>"+"Salary"+"</td></tr>";
					//$("#head").html(th);
					for (var i = 0; i < data.length; i++) {
						str+="<tr><td>"+data[i].teacherId+"</td> <td>"+data[i].salary+"</td> </tr>";
						$("#showallcos").html(str);
						$("#showallu").html("");
					};

					for(var x=0; x < data.length; x++)
					{
						total+=data[x].salary;
					};
					localStorage.ttotal=total;
					$("#showtotal").html("Total Cost: "+total);
					
				}
				else
				{	$("#no").html("No content");
					console.log(xmlHttp.status+":"+xmlHttp.statusText);
				}
			}
	});
}
function StdFin()
{
	var Username=localStorage.Username;
	var Password=localStorage.Password; 
	$.ajax({
			url:"http://localhost:61115/api/AdminHome/StdFinancials",
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
					//var total=0;
					
					str+="<tr><td>"+"Student Name"+"</td><td>"+"Subject Id"+"</td><td>"+"Fee"+"</td></tr>";
					//$("#head").html(th);
					for (var i = 0; i < data.length; i++) {
						str+="<tr><td>"+data[i].studentName+"</td> <td>"+data[i].subjectId+"</td> <td>"+data[i].fee+"</td> </tr>";
						$("#head").html(str);
						$("#showallu").html("");
					};

					for(var x=0; x < data.length; x++)
					{
						stotal+=data[x].fee;
					};
					var bb=localStorage.ttotal;
					profit=stotal-bb;
					$("#stotal").html("Total Earnings: "+stotal);
					$("#profit").html("Total Profit: "+profit);
					
				}
				else
				{	$("#no").html("No content");
					console.log(xmlHttp.status+":"+xmlHttp.statusText);
				}
			}
	});
}

function AllUsers()
{
	var Username=localStorage.Username;
	var Password=localStorage.Password; 
	$.ajax({
			url:"http://localhost:61115/api/AdminHome/allusers",
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
					
					
					str+="<tr><td>"+"User Id"+"</td><td>"+"User Name"+"</td><td>"+"Email"+"</td><td>"+"Password"+"</td><td>"+"Type"+"</td><td>"+"Status"+"</td></tr>";
					//$("#head").html(th);
					for (var i = 0; i < data.length; i++) {
						str+="<tr><td>"+data[i].userId+"</td> <td>"+data[i].userName+"</td><td>"+data[i].email+"</td><td>"+data[i].password+"</td><td>"+data[i].userType+"</td><td>"+data[i].status+"</td> </tr>";
						$("#showallu").html(str);
						$("#head").html("");
						$("#showallcos").html("");
						$("#showtotal").html("");
						$("#stotal").html("");
						$("#profit").html("");
					};

					
					
				}
				else
				{	$("#no").html("No content");
					console.log(xmlHttp.status+":"+xmlHttp.statusText);
				}
			}
	});
}

function AllTea()
{
	var Username=localStorage.Username;
	var Password=localStorage.Password; 
	$.ajax({
			url:"http://localhost:61115/api/AdminHome/allteachers",
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
					
					
					str+="<tr><td>"+"Teacher Id"+"</td><td>"+"Teacher Name"+"</td><td>"+"Mobile"+"</td><td>"+"Address"+"</td><td>"+"Institute"+"</td><td>"+"Salary"+"</td></tr>";
					//$("#head").html(th);
					for (var i = 0; i < data.length; i++) {
						str+="<tr><td>"+data[i].teacherId+"</td> <td>"+data[i].teacherName+"</td><td>"+data[i].mobileNo+"</td><td>"+data[i].address+"</td><td>"+data[i].institute+"</td><td>"+data[i].salary+"</td> </tr>";
						$("#showallu").html(str);
						$("#head").html("");
						$("#showallcos").html("");
						$("#showtotal").html("");
						$("#stotal").html("");
						$("#profit").html("");
					};

					
					
				}
				else
				{	$("#no").html("No content");
					console.log(xmlHttp.status+":"+xmlHttp.statusText);
				}
			}
	});
}
function AllStd()
{
	var Username=localStorage.Username;
	var Password=localStorage.Password; 
	$.ajax({
			url:"http://localhost:61115/api/AdminHome/allStudents",
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
					
					
					str+="<tr><td>"+"Student Id"+"</td><td>"+"Student Name"+"</td><td>"+"Mobile"+"</td><td>"+"Address"+"</td><td>"+"Institute"+"</td></tr>";
					//$("#head").html(th);
					for (var i = 0; i < data.length; i++) {
						str+="<tr><td>"+data[i].studentId+"</td> <td>"+data[i].studentName+"</td><td>"+data[i].mobileNo+"</td><td>"+data[i].address+"</td><td>"+data[i].stdInstitute+"</td></tr>";
						$("#showallu").html(str);
						$("#head").html("");
						$("#showallcos").html("");
						$("#showtotal").html("");
						$("#stotal").html("");
						$("#profit").html("");
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

