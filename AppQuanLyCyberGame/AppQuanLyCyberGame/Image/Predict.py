import numpy as np
import joblib
import sys
import json

product_mapping = {
    'Pepsi': 1,
    'Coca': 2,
    'Sting': 3,
    'C2': 4,
    'Trà xanh 0 độ': 5,
    'Cà phê sữa': 6,
    'Cà phê đá': 7,
    'Mì gói nước': 8,
    'Mì gói khô': 9,
    'Mì gói nước trứng': 10,
    'Mì gói khô trứng': 11,
    'Mì gói nước bò viên': 12,
    'Mì gói khô bò viên': 13,
    'Cơm gà xối mỡ': 14,
    'Cơm xào thịt bò': 15,
    'Hủ tiếu bò viên': 16,
    'Warrior': 17,
    'Wakeup 247': 18,
    'Fanta': 19,  
    'Mirinda': 20  
}
product_name_input = sys.argv[1]

model = joblib.load('F:\DA2\VS2019\AppQuanLyCyberGame\AppQuanLyCyberGame\Image\AI.joblib')
def predict_next_products(product_name, model, product_mapping, n=4):
    # Chuyển đổi tên sản phẩm thành mã hóa
    product_encoded = product_mapping.get(product_name)
    if product_encoded is None:
        return ""

    # Dự đoán xác suất cho tất cả các sản phẩm
    all_products = list(product_mapping.keys())
    all_products_encoded = list(product_mapping.values())
    probabilities = model.predict_proba(np.array(all_products_encoded).reshape(-1, 1))

    # Lấy xác suất dự đoán cho sản phẩm tiếp theo
    next_product_probabilities = probabilities[:, product_encoded - 1]

    # Sắp xếp các sản phẩm theo xác suất giảm dần
    sorted_indices = np.argsort(next_product_probabilities)[::-1]

    # Lấy n sản phẩm có xác suất cao nhất
    top_n_indices = sorted_indices[:n]
    top_n_products = [all_products[i] for i in top_n_indices]
    top_n_probabilities = [next_product_probabilities[i] for i in top_n_indices]

    return list(top_n_products)
result = predict_next_products('Sting',model,product_mapping)
print(json.dumps(result,ensure_ascii=False))


