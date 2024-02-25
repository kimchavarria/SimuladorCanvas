// Selecciona el formulario con el atributo 'action' igual a la URL de la API de inicio de sesión y agrega un evento 'submit'
document.querySelector('form[action="http://localhost:59901/api/login"]').addEventListener('submit', function (event) {
    // Previene el comportamiento del form, enviar la solicitud al servidor y recargar la página
    event.preventDefault();

    // Obtiene el valor del correo electrónico
    const email = document.getElementById('username').value;

    // Expresión regular para validar los dominios permitidos
    const allowedDomains = /@(ulacit\.ed\.cr|ulacit\.ac\.cr)$/;

    // Verifica si el correo electrónico coincide con los dominios permitidos
    if (!allowedDomains.test(email)) {
        // Si el correo electrónico no coincide, muestra la alerta y detiene la ejecución
        document.getElementById('username').value = ''; // Limpiar el campo de username
        document.getElementById('alert').style.display = 'block';
        return;
    }

    // Realiza un fetch a la URL de la API de inicio de sesión con el método POST
    fetch('http://localhost:59901/api/login', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json' // Especifica el contenido de la solicitud como JSON
        },
        // Convierte los datos del form en un objeto JSON y los envía 
        body: JSON.stringify({
            username: email, // Obtiene el valor nombre de usuario
            password: document.getElementById('password').value, // Obtiene el valor de contraseña
            userType: document.getElementById('userType').value // Obtiene el valor tipo de usuario
        })
    })
        .then(response => {
            // Verifica si la respuesta de la solicitud es exitosa 
            if (response.ok) {
                // Si la respuesta es exitosa, devuelve los datos de respuesta como JSON
                return response.json();
            } else {
                // Si la respuesta no es exitosa, lanza un error con el código de estado de la respuesta
                throw new Error(response.status);
            }
        })
        .then(data => {
            // Maneja los datos de respuesta JSON
            if (data.message === 'Login successful') { // Verifica si el mensaje de la respuesta es 'Login Succesful'
                if (data.userType === 'student') { // Si el tipo de usuario es 'student'
                    // Redirige a la página StudentMod.html
                    window.location.href = 'StudentMod.html';
                } else if (data.userType === 'faculty') { // Si el tipo de usuario es 'faculty'
                    // Redirige a la página FacultyMod.html
                    window.location.href = 'FacultyMod.html';
                }
            } else {
                // Si el mensaje de la respuesta no es 'Login Succesful', muestra un mensaje de error en la consola
                console.error('Login failed');
                document.getElementById('password').value = ''; // Limpiar el campo de contraseña
                document.getElementById('alert1').style.display = 'block'; // Muestra la alerta
            }
        })
        .catch(error => {
            // Maneja los errores relacionados con el proceso de inicio de sesión
            console.error('Login error:', error);
            document.getElementById('password').value = ''; // Limpiar el campo de contraseña
            document.getElementById('alert1').style.display = 'block'; // Muestra la alerta
        });
});
