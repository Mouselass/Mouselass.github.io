let form = document.getElementById('applicationForm');

form.addEventListener("submit", function (event) {
    event.preventDefault();
    new FormData(form);
});

form.addEventListener("formdata", event => {
    const data = event.formData;
    const values = [...data.values()];

    console.log(values);

    let contactInput = data.get("contactInput");
    let problemSelect = data.get("problemSelect");
    let problemInput = data.get("problemInput");

    if (contactInput.length == 0 || problemInput.length == 0 || problemSelect == null) {
        Swal.fire('Не все поля заполнены', 'Введите все данные', 'error');
        return;
    }
    if (problemInput.length < 30) {
        Swal.fire('Более подробно опишите свою проблему', 'В описании проблемы необходимо не менее 30 символов', 'warning');
        return;
    }
    Swal.fire('Успех', 'Заявка успешно оставлена', 'success');
});