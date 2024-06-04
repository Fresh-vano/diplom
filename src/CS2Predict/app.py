from flask import Flask, request, jsonify
from flask_migrate import Migrate
from model.db_models import db
from services.prediction_service import PredictionService

app = Flask(__name__)
app.config['SQLALCHEMY_DATABASE_URI'] = 'postgresql://postgres:11111111@localhost:5432/CS2'
app.config['SQLALCHEMY_TRACK_MODIFICATIONS'] = False

db.init_app(app)
migrate = Migrate(app, db)
prediction_service = PredictionService(app)

@app.route('/predict', methods=['POST'])
def predict():
    data = request.get_json()
    match_id = data.get('matchId')
    
    if match_id is None:
        return jsonify({'error': 'Invalid input, matchId is required'}), 400
    
    try:
        prediction = prediction_service.predict(match_id)
        return jsonify(prediction)
    except Exception as e:
        return jsonify({'error': str(e)}), 500

if __name__ == '__main__':
    app.run(host='0.0.0.0', port=5000)