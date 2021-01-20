<?php
    include 'conexion.php';

    if ($_SERVER["REQUEST_METHOD"] == 'GET') {
        //Buscar usuario
        if(isset($_GET["usuario"])){
            $usuario = $_GET["usuario"];
            $sql = "SELECT * FROM accesos WHERE usuario='$usuario'";
            $query = $con -> prepare($sql);
            $query -> execute();
            $results = $query -> fetchAll(PDO::FETCH_OBJ);
            if ($query -> rowCount() > 0) {
                echo json_encode($results);
            } 
            $con = null;
        }
    }

?>