<script>
    document.addEventListener("DOMContentLoaded", function () {
        // Lấy danh sách sản phẩm
        var products = document.getElementById("doca");

    // Lắng nghe sự kiện khi người dùng nhấp vào các liên kết sắp xếp
    document.querySelectorAll(".content_ul a").forEach(function (link) {
        link.addEventListener("click", function (e) {
            e.preventDefault();

            // Lấy loại sắp xếp từ thuộc tính data-sort-order
            var sortOrder = link.getAttribute("data-sort-order");

            // Gọi action SortProducts với sortOrder tương ứng
            window.location.href = "/SanPham/SortProducts?sortOrder=" + sortOrder;
        });
        });
    });
</script>