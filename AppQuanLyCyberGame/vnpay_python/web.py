from flask import Flask, jsonify, request
import joblib
import numpy as np
import spacy
import pyodbc

app = Flask(__name__)

def predict_next_products(product_name, model, n=4):
    # Chuyển đổi tên sản phẩm thành mã hóa
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
    'Fanta': 19,  # Thêm Fanta với giá trị số 19
    'Mirinda': 20  # Thêm Mirinda với giá trị số 20
    }
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

    return top_n_products

@app.route('/predict', methods=['POST'])
def predict():
    try:
        model_path = 'F:/DA2/VS2019/AppQuanLyCyberGame/AppQuanLyCyberGame/Image/AI.joblib'
        model = joblib.load(model_path)
        
        data = request.json
        product_name = data.get('product_name')

        predictions = predict_next_products(product_name, model)
        result = predictions[0] if predictions else "No prediction available"
        return jsonify(predictions)
    except Exception as e:
        return "Error: " + str(e)
server = 'DESKTOP-CRGLG1U'
database = 'QuanLyCyberGame'
driver = '{ODBC Driver 17 for SQL Server}'


@app.route('/ok', methods=['POST'])
def handle_form_submission():
    if request.method == 'POST':
        amount = request.form['amount']
        user_id = request.form['user_id']

        # Kết nối đến cơ sở dữ liệu sử dụng Windows Authentication
        conn = pyodbc.connect('DRIVER=' + driver + ';SERVER=' + server + ';DATABASE=' + database + ';Trusted_Connection=yes;')
        cursor = conn.cursor()

        # Thực hiện truy vấn UPDATE để cập nhật dữ liệu trong bảng
        cursor.execute("UPDATE Users SET balance = balance + ? WHERE Id = ?", (amount, user_id))
        conn.commit()

        # Đóng kết nối
        cursor.close()
        conn.close()

        # Trả về một phản hồi cho người dùng
        return "Dữ liệu đã được cập nhật thành công!"

if __name__ == '__main__':
    app.run(debug=True)



