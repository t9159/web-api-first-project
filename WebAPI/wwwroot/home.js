
const SignIn = async () => {
    try {
        const user = {
            id: 0,
            email: document.querySelector("#email").value,
            password: document.querySelector("#password").value,
            firstName: document.querySelector("#firstName").value,
            lastName: document.querySelector("#lastName").value
        }
        const post = await fetch('api/users', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(user)
        });
        const dataPost = await post.json();
        if (post.ok)
            alert(`שלום, נרשמת בהצלחה הנך משתמש מספר ${dataPost.id}`);
        else {
            throw ("ההרשמה לא הצליחה, נסה שוב");
        }
    }
    catch (e) {
            alert (e);
    }
        
}
const StrongPass = async () => {
    try {
        const password=document.querySelector("#password").value
        const post = await fetch('api/strongPassword', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(password)

        });
        const dataPost = await post.json();
        if (post.ok) {
            const sPass = document.querySelector("#sPass")
            sPass.value = dataPost.score
        }
        else {
            throw ("שגיאה")
        }
    }
    catch (e) {
        alert(e);
    }
  }

const LogIn = async () => {
    try {
        const user = {
            email: document.querySelector("#logemail").value,
            password: document.querySelector("#logpassword").value,
        }
        const post = await fetch('api/users/Login', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(user)

        });
        const dataPost = await post.json();
        if (post.ok) {
            sessionStorage.setItem('CurrentUser', JSON.stringify(dataPost))
            window.location.href = "Login.html"
        }
        else {
            throw ("משתמש לא קיים")
        }
    }
    catch (e) {
            alert(e);
        }
    }

