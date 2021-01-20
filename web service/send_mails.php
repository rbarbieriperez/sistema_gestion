<?php
    include 'conexion_db.php';
    function SendMail($correo,$codigo){
        //Enviar código de recuperación de usuario.-
        $subject = "CODIGO DE RECUPERACION DE USUARIOS";
        $message = "Su código de reucperación es $codigo";
        $headers = "From: rbarbieriperez@gmail.com";
        if(mail($correo,$subject,$message,$headers)){
            return 1;
        } else {
            return 0;
        }
    
    }
    
    
    


?>