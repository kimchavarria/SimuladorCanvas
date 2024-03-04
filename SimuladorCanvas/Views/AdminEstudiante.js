// Fetch students data
function fetchStudents() {
    var xhr = new XMLHttpRequest();
    xhr.open("GET", "/api/students", true);
    xhr.setRequestHeader("Content-Type", "application/json");

    xhr.onreadystatechange = function () {
        if (xhr.readyState === 4) {
            if (xhr.status === 200) {
                displayStudents(JSON.parse(xhr.responseText));
            } else {
                console.error("Failed to fetch students");
            }
        }
    };

    xhr.send();
}

// Display students in a table
function displayStudents(students) {
    var studentTableBody = document.getElementById("studentTable").getElementsByTagName("tbody")[0];

    students.forEach(function (student) {
        var row = studentTableBody.insertRow();
        row.insertCell(0).innerText = student.student_id;
        row.insertCell(1).innerText = student.firstName;
        row.insertCell(2).innerText = student.lastName;
        row.insertCell(3).innerText = student.email;
    });
}

// Fetch and display registration data
function fetchAndDisplayRegistrationData() {
    $.ajax({
        url: '/api/registro',
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            displayRegistrationData(data);
        },
        error: function (xhr, status, error) {
            console.error('Error al cargar los datos de REGISTRO:', error);
        }
    });
}

// Display registration data in a table
function displayRegistrationData(data) {
    var registroTableBody = $('#registroTableBody');
    registroTableBody.empty();

    $.each(data, function (index, registro) {
        registroTableBody.append('<tr>' +
            '<td>' + registro.student_id + '</td>' +
            '<td>' + registro.course_id + '</td>' +
            '<td>' + registro.course_name + '</td>' +
            '<td>' + registro.student_name + '</td>' +
            '<td>' + registro.student_email + '</td>' +
            '</tr>');
    });
}

// Logout function
function logout() {
    if (confirm("Are you sure you want to log out?")) {
        window.location.href = 'login.html';
    } else {
        // Do nothing if the user cancels logout
    }
}

// Event listener for form submission
document.getElementById("registrationForm").addEventListener("submit", function (event) {
    event.preventDefault();

    var formData = {
        student_id: document.getElementById("student_id").value,
        course_id: document.getElementById("course_id").value
    };

    fetchStudentInfo(formData);
    registerStudentToCourse(formData);
});

// Fetch student info
function fetchStudentInfo(formData) {
    var xhr = new XMLHttpRequest();
    xhr.open("GET", "/api/students/" + formData.student_id, true);
    xhr.setRequestHeader("Content-Type", "application/json");

    xhr.onreadystatechange = function () {
        if (xhr.readyState === 4) {
            if (xhr.status === 200) {
                var student = JSON.parse(xhr.responseText);
                document.getElementById("student_name").value = student.student_name;
            } else {
                document.getElementById("student_name").value = "Unknown";
            }
        }
    };

    xhr.send();
}

// Register student to course
function registerStudentToCourse(formData) {
    var xhr = new XMLHttpRequest();
    xhr.open("POST", "/api/faculty/register", true);
    xhr.setRequestHeader("Content-Type", "application/json");

    xhr.onreadystatechange = function () {
        if (xhr.readyState === 4) {
            if (xhr.status === 200) {
                var response = JSON.parse(xhr.responseText);
                document.getElementById("responseMessage").innerText = response.message;

                // Después de registrar al estudiante, actualiza la tabla de estudiantes registrados
                fetchAndDisplayRegistrationData();
            } else {
                document.getElementById("responseMessage").innerText = "Failed to register student to the course";
            }
        }
    };

    xhr.send(JSON.stringify(formData));
};

// Load necessary data on page load
$(document).ready(function () {
    fetchStudents();
    fetchAndDisplayRegistrationData();
});