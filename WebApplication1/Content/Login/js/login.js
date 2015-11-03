var attempt = 3;

function validate(){
	var username = document.getElementById("username").value;
	var password = document.getElementById("password").value;

	if ( username == "david" && password == "david123"){
		alert ("Ha ingresado correctamente");
		window.location = "bienvenido.html"; //redirecting to other page
		return false;
	}
	else{
		attempt --;
		alert("Tienes "+attempt+" intentos;");
		
		if( attempt == 0){
			document.getElementById("username").disabled = true;
			document.getElementById("password").disabled = true;
			document.getElementById("submit").disabled = true;
			return false;
		}
	}
}