
function login(){
    var  password = document.getElementById("password").value;
    var  username = document.getElementById("username").value;
    if(username == ''){
        alert("insira o Usuario");
    }else if(password  == ''){
        alert("insira o Password");
    }else{
        //redirecionar para outra pagina
        location.href="eventos.html";
    }
    
}
