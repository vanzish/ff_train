import React, { Component } from 'react';
import DatePicker from 'react-date-picker';
import Cities from './cities';

class Search extends Component {
    constructor(props) {
        super(props);
        this.handleDepartureCityChange = this.handleDepartureCityChange.bind(this);
        this.handleArrivalCityChange = this.handleArrivalCityChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
        this.onDateChange = this.onDateChange.bind(this);
        this.showSeatsHandle = this.showSeatsHandle.bind(this);

        this.state = {
            depCityId: 0,
            arrCityId: 0,
            dateTime: new Date(),
            cities: [],
            showTrain: false,
            runs: [],
            train: {},
        }
    };

    onDateChange = date => this.setState({ dateTime: date })

    componentDidMount() {
        fetch('https://localhost:5001/railways/cities')
            .then(res => res.json())
            .then(responseJson => {
                if (!this.isCancelled) {
                    const results = responseJson.cities.map(city => ({
                        id: city.id,
                        name: city.name,
                    }));
                    this.setState({ cities: results });
                }
            })
            .catch(() => this.setState({ hasErrors: true }));
    }

    async handleSubmit(event) {
        event.preventDefault();

        const url = 'https://localhost:5001/railways/runs';
        const data = { DepartureCityId: this.state.depCityId, DestinationCityId: this.state.arrCityId, DepartureDate: this.state.dateTime };
        console.log(data);
        try {
            const response = await fetch(url, {
                method: 'POST',
                body: JSON.stringify(data),
                headers: {
                    'Content-Type': 'application/json'
                }
            });
            const json = await response.json();

            this.setState({ runs: json.runs })
            console.log('Успех:', JSON.stringify(json));
        } catch (error) {
            console.error('Ошибка:', error);
        }
    }

    async showSeatsHandle(runId) {
        console.log(runId);
        const url = 'https://localhost:5001/railways/seats';
        const data = { RunId: runId };
        console.log(data);
        try {
            const response = await fetch(url, {
                method: 'POST',
                body: JSON.stringify(data),
                headers: {
                    'Content-Type': 'application/json'
                }
            });
            const json = await response.json();

            this.setState({ train: json.run.train, showTrain: true })
            console.log('Успех:', JSON.stringify(json));
        } catch (error) {
            console.error('Ошибка:', error);
        }
    }


    handleDepartureCityChange(cityId) {
        this.setState({ depCityId: cityId })
    }
    handleArrivalCityChange(cityId) {
        this.setState({ arrCityId: cityId })
    }
    render() {
        const depId = this.state.depCityId;
        const arrId = this.state.arrCityId;
        const cities = this.state.cities;
        const runs = this.state.runs;
        const train = this.state.train;
        return (
            <div className="container">
                <h1>Поиск билетов</h1>
                <form onSubmit={this.handleSubmit}>
                    Откуда: <Cities onCityChange={this.handleDepartureCityChange} cityId={depId} cities={cities} />
                    Куда: <Cities onCityChange={this.handleArrivalCityChange} cityId={arrId} cities={cities} />
                    День отправления:  <DatePicker
                        onChange={this.onDateChange}
                        value={this.state.date} />
                    <input type="submit" value="Искать" />
                </form>
                {runs && runs.length > 0 &&
                    <div>

                        <ul>
                            {runs.map((run) =>
                                <li key={run.id}><button onClick={() => this.showSeatsHandle(run.id)} value={run.id}><h2>{run.route.name}</h2></button>&nbsp;<span>Время отправления: {new Date(run.runTime).toLocaleDateString("ru")} в {new Date(run.runTime).toLocaleTimeString("ru")}</span></li>
                            )}
                        </ul>
                    </div>
                }
                {this.state.showTrain && runs && runs.length > 0 &&
                    <div>
                        <h3>{train.number}</h3>
                        {
                            train.carriages.map(carriage =>
                                <div key={carriage.id}>
                                    <h4>Номер вагона: {carriage.number}</h4>
                                    <ul>
                                        {carriage.seats.map(seat =>
                                            <div key={seat.id}>
                                                {
                                                    seat.isBusy === false &&
                                                    <li>Номер - {seat.number}, {seat.seatType.position === 0 ? ("Верхнее") : ("Нижнее")} {seat.seatType.isOutboard === true && "боковое"}</li>
                                                }
                                            </div>
                                        )}
                                    </ul>
                                </div>
                            )}
                    </div>
                }
            </div>
        );
    }
}

export default Search