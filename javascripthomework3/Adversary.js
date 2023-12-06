class Adversary {
    constructor(m, n, p) {
        this.M = m;
        this.N = n;
        this.P = p;

        this.lineChartValuesChart1 = [];
        this.lineChartValuesChart2 = [];
        this.lineChartValuesChart3 = [];
        this.lineChartValuesChart4 = [];
        
        this.generateAttacks();
    }

    generateAttacks() {
        let random = Math.random();

        for (let i = 0; i < this.M; i++) {
            const valuesChart1 = [];
            const valuesChart2 = [];

            for (let j = 0; j < this.N; j++) {
                // Generate random from (0, 1]
                let randomNumber = Math.random();

                if (randomNumber > this.P) {
                    // Attack success
                    valuesChart1.push(-1);
                    valuesChart2.push(1);
                } else {
                    // Attack failed
                    valuesChart1.push(1);
                    valuesChart2.push(0);
                }
            }
            this.lineChartValuesChart1.push(valuesChart1);
            this.lineChartValuesChart2.push(valuesChart2);
        }

        this.createChart3Values();
        this.createChart4Values();
    }

    createChart3Values() {
        for (let i = 0; i < this.lineChartValuesChart2.length; i++) {
            const systemIValues = [0];
            let sum = 0;

            for (let j = 0; j < this.lineChartValuesChart2[i].length; j++) {
                sum += this.lineChartValuesChart2[i][j];
                systemIValues.push(sum / (j + 1));
            }
            this.lineChartValuesChart3.push(systemIValues);
        }
    }

    createChart4Values() {
        for (let i = 0; i < this.lineChartValuesChart2.length; i++) {
            const systemIValues = [0];
            let sum = 0;

            for (let j = 0; j < this.lineChartValuesChart2[i].length; j++) {
                sum += this.lineChartValuesChart2[i][j];
                systemIValues.push(sum / Math.sqrt(j + 1));
            }
            this.lineChartValuesChart4.push(systemIValues);
        }
    }

    createHistoDistrib(values) {
        const finalValues = {};

        for (let i = 0; i < values.length; i++) {
            let sum = 0;

            for (let s = 0; s < values[i].length; s++) {
                sum += values[i][s];
            }
            finalValues[i] = sum;
        }

        return finalValues;
    }

    createHistoDistribFloat(values) {
        const finalValues = {};

        for (let i = 0; i < values.length; i++) {
            finalValues[i] = values[i][values[i].length - 1];
        }

        return finalValues;
    }

    getLineChart1AttackList() {
        return this.lineChartValuesChart1;
    }

    getLineChart2AttackList() {
        return this.lineChartValuesChart2;
    }

    getLineChart3AttackList() {
        return this.lineChartValuesChart3;
    }

    getLineChart4AttackList() {
        return this.lineChartValuesChart4;
    }
}
