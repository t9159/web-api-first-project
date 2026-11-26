const currUser = JSON.parse(sessionStorage.getItem("CurrentUser"))
welcomeText.textContent = `Hi ${currUser.firstName}, You have successfully logged in`

const strongPass = async (password) => {
    try {
        const post = await fetch('api/strongPassword', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(password)

        });
        if (post.ok) {
            const dataPost = await post.json();
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

const displayDetails = () => {
    const upDetails = document.querySelector(".upDetails")
    const updateEmail = document.querySelector("#updateEmail")
    const updatePassword = document.querySelector("#updatePassword")
    const updateFirstName = document.querySelector("#updateFirstName")
    const updateLastName = document.querySelector("#updateLastName")
    upDetails.style.display = "block"
    updateEmail.value = currUser.email
    updatePassword.value = currUser.password
    updateFirstName.value = currUser.firstName
    updateLastName.value = currUser.lastName

}
const updateDetails = async () => {
    try {
        const user = {
            id: currUser.id,
            email: document.querySelector("#updateEmail").value,
            password: document.querySelector("#updatePassword").value,
            firstName: document.querySelector("#updateFirstName").value,
            lastName: document.querySelector("#updateLastName").value,
        }
        const strong = await strongPass(user.password);
        if (strong < 3)
            throw ("סיסמא חלשה!")
        const putData = await fetch(`api/users/${currUser.id}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(user)

        });
        if (putData.ok) {
            sessionStorage.setItem("CurrentUser", JSON.stringify(user))
            alert("update successfuly")
        }
        else if (post.status == 400)
            throw("הסיסמא חלשה")
        else {
            throw ("error on the update")
        }
    }
    catch (e) {
        alert(e);
    }
}