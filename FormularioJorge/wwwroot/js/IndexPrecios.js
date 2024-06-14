let litros = 200000;


function Mostrardiferentes(selectElement) {
    var selectedValue = selectElement.value;
    switch (selectedValue) {
        case '0':
                document.getElementById('numero1').hidden = false;
                document.getElementById('numero2').hidden = true;
                document.getElementById('numero3').hidden = true;
            break;
        case '1':
            document.getElementById('numero1').hidden = true;
            document.getElementById('numero2').hidden = false;
            document.getElementById('numero3').hidden = true;
            break;
        case '2':
            document.getElementById('numero1').hidden = true;
            document.getElementById('numero2').hidden = true;
            document.getElementById('numero3').hidden = false;
            break;

    }


}
function PantallaPrincipal(obj) {
    
    switch (obj) {
        case 0:
            document.getElementById('Precios').hidden = false;
                document.getElementById('Ordenes').hidden = true;
                
            break;
        case 1:
            document.getElementById('Precios').hidden = true;
            document.getElementById('Ordenes').hidden = false;

            break;

    }

}


function actualizarCantidadLitrosMas() {

    litros += 100;
    var label = document.getElementById("CantidadLitros");
    label.innerHTML = litros;

}

function actualizarCantidadLitrosMenos() {
    litros -= 100;
    var label = document.getElementById("CantidadLitros");
    label.innerHTML = litros;

}
function HabilidarBotonOC() {
    document.getElementById('CrearOC').disabled = false;
}

