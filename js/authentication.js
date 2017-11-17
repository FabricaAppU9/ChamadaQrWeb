
function login(){
    var  password = document.getElementById("password").value;
    var  username = document.getElementById("username").value;
    if(username == ''){
        //alert("insira o Usuario");
        Materialize.toast('insira o Usuario', 3000, 'rounded')
    }else if(password  == ''){
        //alert("insira o Password");
        Materialize.toast('insira o Password', 3000, 'rounded')    
    }else{
        //redirecionar para outra pagina
        location.href="eventos.html";
    }
    
}

  $('.modal').modal({
    dismissible: false, // Modal can be dismissed by clicking outside of the modal
    opacity: .5, // Opacity of modal background
    inDuration: 300, // Transition in duration
    outDuration: 200, // Transition out duration
    startingTop: '4%', // Starting top style attribute
    endingTop: '10%', // Ending top style attribute
    ready: function(modal, trigger) { // Callback for Modal open. Modal and trigger parameters available.
      console.log(modal, trigger);
    },
    complete: function() {  } // Callback for Modal close
  }
);