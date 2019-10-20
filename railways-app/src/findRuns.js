import React, { Component } from 'react';

class Search extends Component {
    constructor(props) {
        super(props);
        this.handleDepartureCityChange = this.handleDepartureCityChange.bind(this);
        this.handleArrivalCityChange = this.handleArrivalCityChange.bind(this);

        this.state = {
            depCityId: 0,
            arrCityId: 0,
            dateTime: {},
            cities: []
        }
    };

    componentDidMount() {
        fetch('https://localhost:5001/railways/cities')
            .then(res => res.json())
            .then(responseJson => {
                if (!this.isCancelled) {
                    const results = responseJson.cities.map(city => ({
                        id: city.id,
                        name: city.name,
                    }))
                    this.setState({ cities: results });
                }
            })
            .catch(() => this.setState({ hasErrors: true }));
    }

    handleSubmit(event) {
        alert('Отправленное имя: ' + this.state.value);
        event.preventDefault();
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
        return (
            <div>
                <h1>Поиск билетов</h1>
                <form onSubmit={this.handleSubmit}>
                    Откуда: <Cities onCityChange={this.handleDepartureCityChange} cityId={depId} cities={cities} />
                    Куда: <Cities onCityChange={this.handleArrivalCityChange} cityId={arrId} cities={cities} />
                    <div>День отправления:</div>
                    <input type="submit" value="Искать" />
                </form>
            </div>
        );
    }
}

export default Search