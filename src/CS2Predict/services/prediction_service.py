import numpy as np
from model.predictor_model import PredictorModel
from model.db_models import db, Match, TeamResultMetric

class PredictionService:
    def __init__(self, app):
        self.model = PredictorModel()
        self.model.load_weights('weights.h5')
        db.init_app(app)
        self.app = app

    def predict(self, match_id):
        with self.app.app_context():
            match = Match.query.get(match_id)
            if match is None:
                raise ValueError(f"No match data found for matchId: {match_id}")

            team1_metrics = self._get_team_metrics(match.team1_id)
            team2_metrics = self._get_team_metrics(match.team2_id)

            input_data = self._format_data(team1_metrics, team2_metrics)
            prediction = self.model.predict(input_data)
            
            return {
                'prediction': {
                    'winProbability': float(prediction[0][0]),
                }
            }

    def _get_team_metrics(self, team_id):
        metrics = TeamResultMetric.query.filter_by(team_id=team_id).order_by(TeamResultMetric.match_id.desc()).limit(5).all()
        if not metrics:
            raise ValueError(f"No metrics found for teamId: {team_id}")

        combined_metrics = np.zeros(9)
        for metric in metrics:
            combined_metrics += np.array([
                metric.kill_count,
                metric.death_count,
                metric.assist_count,
                metric.round_won_count,
                metric.round_lost_count,
                metric.utility_buy, 
                metric.utility_use, 
                metric.trade_kill_count, 
                metric.trade_death_count
            ])
        combined_metrics /= len(metrics)
        return combined_metrics

    def _format_data(self, team1_metrics, team2_metrics):
        return np.array([np.concatenate((team1_metrics, team2_metrics))])
