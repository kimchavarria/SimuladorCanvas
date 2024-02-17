document.querySelector('form[action="http://localhost:59901/api/login"]').addEventListener('submit', function (event) {
    event.preventDefault();

    fetch('http://localhost:59901/api/login', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            username: document.getElementById('username').value,
            password: document.getElementById('password').value,
            userType: document.getElementById('userType').value
        })
    })
        .then(response => {
            if (response.ok) {
                return response.json();
            } else {
                throw new Error('Network response was not ok');
            }
        })
        .then(data => {
            if (data.message === 'Login successful') {
                if (data.userType === 'student') {
                    window.location.href = 'StudentMod.html';
                } else if (data.userType === 'faculty') {
                    window.location.href = 'FacultyMod.html';
                }
            } else {
                console.error('Login failed');
            }
        })
        .catch(error => {
            console.error('Error:', error);
        });
});
