
const strongPass = async () => {
    try {
        const password = document.querySelector("#password").value
        const post = await fetch('api/strongPassword', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(password)

        });
        if (post.ok) {
            const dataPost = await post.json();
            const sPass = document.querySelector("#sPass")
            sPass.value = dataPost.score
            return dataPost.score
        }
        else {
            throw ("שגיאה")
        }
    }
    catch (e) {
        alert(e);
    }
}



const signIn = async () => {
    try {
        const user = {
            id: 0,
            email: document.querySelector("#email").value,
            password: document.querySelector("#password").value,
            firstName: document.querySelector("#firstName").value,
            lastName: document.querySelector("#lastName").value
        }
        const strong = await strongPass();
        if (strong < 3)
            throw("סיסמא חלשה!")
        const post = await fetch('api/users', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(user)
        });
        if (post.ok&&post.status==201)
        {
            const dataPost = await post.json();
            console.log(dataPost.firstName)
            alert(`שלום ${dataPost.firstName}, נרשמת בהצלחה הנך משתמש מספר ${dataPost.id}`);
        }
        else if (post.status == 400)
            throw("הסיסמא חלשה")
        else {
            throw ("ההרשמה לא הצליחה, נסה שוב");
        }
    }
    catch (e) {
            alert (e);
    }
        
}


const logIn = async () => {
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
        if (post.ok && post.status == 200) {
            const dataPost = await post.json();
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

