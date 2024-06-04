package test

import (
	"math"
	"testing"

	Analyzer "github.com/Fresh-vano/CS2-Parser/analyzer"
)

const (
	AverageKPR float64 = 0.679 // average kills per round
	AverageSPR float64 = 0.317 // average survived rounds per round
	AverageRMK float64 = 1.277 // average value calculated from rounds with multiple kills
)

func TestComputeHltvOrgRating(t *testing.T) {
	tests := []struct {
		roundCount int
		kills      int
		deaths     int
		nKills     []int
		expected   float64
	}{
		{27, 19, 21, []int{6, 2, 3, 0, 0}, 1.006},
		{27, 24, 18, []int{11, 3, 3, 0, 0}, 1.295},
		{25, 24, 11, []int{9, 4, 1, 1, 0}, 1.562},
	}

	for _, tt := range tests {
		t.Run("", func(t *testing.T) {
			rating := Analyzer.ComputeHltvOrgRating(tt.roundCount, tt.kills, tt.deaths, tt.nKills)
			if math.Abs(rating-tt.expected) > 0.001 {
				t.Errorf("ComputeHltvOrgRating() = %v, want %v", rating, tt.expected)
			}
		})
	}
}
