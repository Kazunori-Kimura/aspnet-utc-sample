$(function() {
    $('.created-utc').each(function (index, element) {
        const $elm = $(element);
        const value = $elm.text();
        console.log(value);

        const d = new Date(value);
        const y = d.getFullYear();
        const m = d.getMonth() + 1;
        const dy = d.getDate();
        const h = d.getHours();
        const mi = d.getMinutes();
        const s = d.getSeconds();

        $elm.siblings('.created-jst').text(`${y}/${m}/${dy} ${h}:${mi}:${s}`);
    });
});