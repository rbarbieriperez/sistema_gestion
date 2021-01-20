<?php
    require_once("conexion_db.php");
    require_once("funciones_generales.php");
    //Consultas
    if ($_SERVER["REQUEST_METHOD"] == 'GET') {
        //Buscar usuario
        if(isset($_GET["usuario"]) && isset($_GET["password"])){
            $usuario = $_GET["usuario"];
            $password = $_GET["password"];
            $sql = "SELECT * FROM usuarios WHERE usuario='$usuario' and password ='$password'";
            $query = $con -> prepare($sql);
            $query -> execute();
            $results = $query -> fetchAll(PDO::FETCH_OBJ);
            if ($query -> rowCount() > 0) {
                echo json_encode($results);
            } 
            $con = null;
        }
        if(isset($_GET["value"]) && isset($_GET["option"])){
            $value = $_GET["value"];
            $option = $_GET["option"]; 
            $sql = "SELECT cod_recuperacion,usuario,correo FROM usuarios WHERE $option='$value';";
            $query = $con -> prepare($sql);
            $query -> execute();
            $results = $query -> fetchAll(PDO::FETCH_OBJ);
            if ($query -> rowCount() > 0) {
                echo json_encode($results);
            } 
            $con = null;
        }
    }
    //Insertar
   /* if ($_SERVER['REQUEST_METHOD' == 'POST']){
        //
    }*/
    //Modificar
    if ($_SERVER['REQUEST_METHOD'] == 'POST'){
        if (isset($_POST["MAC"]) && isset($_POST["usuario"])){
            //Modificar MAC
            $MAC = $_POST["MAC"];
            $usuario = $_POST["usuario"];
            $sql = "UPDATE usuarios SET MAC ='$MAC' WHERE usuario='$usuario';";
            $query = $con -> prepare($sql);
            if ($query -> execute()){
                echo 1;
            } else {
                echo 0;
            }
        }
        if(isset($_POST["usuario"]) && isset($_POST["fecha"]) && isset($_POST["hora"])){
            //Guardar acceso
            $usuario = $_POST["usuario"];
            $fecha = $_POST["fecha"];
            $hora = $_POST["hora"];
            $sql = "INSERT INTO accesos(usuario,fecha,hora) VALUES('$usuario','$fecha','$hora');";
            $query = $con -> prepare($sql);
            if ($query -> execute()){
                echo 1;
            } else {
                echo 0;
            }
        }
        //Guardar código
        if(isset($_POST["usuario"]) && isset($_POST["correo"])){

            //Guardar acceso
            $usuario = $_POST["usuario"];
            $correo = $_POST["correo"];
            $codigo = GenerateRecuperationCode();
            $sql = "UPDATE usuarios SET cod_recuperacion='$codigo' WHERE usuario ='$usuario';";
            $query = $con -> prepare($sql);
            if ($query -> execute()){
                if (SendMail($correo,$codigo) == 1){
                    echo 1;
                } else{
                    echo 0;
                    //Si falla el envío del mail, eliminamos el código generado de la base de datos.
                    $result = 0;
                    while ($result = 0){
                        $sql = "UPDATE usuarios SET cod_recuperacion='' WHERE usuario ='$usuario';";
                        $query = $con -> prepare($sql);
                        if($query -> execute()){
                            $result = 1;
                        }
                    }
                    
                    
                }
            } else {
                echo 0;
            }
        }

    }
?>