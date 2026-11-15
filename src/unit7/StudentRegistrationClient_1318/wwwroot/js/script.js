// Show the entered details below the form without reloading the page.
document.getElementById("studentForm").addEventListener("submit", function (event) {
    event.preventDefault();

    const name = document.getElementById("name").value;
    const email = document.getElementById("email").value;
    const phone = document.getElementById("phone").value;
    const address = document.getElementById("address").value;
    const gender = document.querySelector('input[name="gender"]:checked').value;
    const course = document.getElementById("course").value;

    const studentInfo = document.getElementById("studentInfo");
    studentInfo.innerHTML = `
        <h2>Student Information</h2>
        <p><strong>Full Name:</strong> ${escapeHtml(name)}</p>
        <p><strong>Email:</strong> ${escapeHtml(email)}</p>
        <p><strong>Phone:</strong> ${escapeHtml(phone)}</p>
        <p><strong>Address:</strong> ${escapeHtml(address)}</p>
        <p><strong>Gender:</strong> ${escapeHtml(gender)}</p>
        <p><strong>Course:</strong> ${escapeHtml(course)}</p>
    `;
    studentInfo.style.display = "block";
});

// Typed text is shown as text, not run as HTML.
function escapeHtml(text) {
    const div = document.createElement("div");
    div.textContent = text;
    return div.innerHTML;
}
