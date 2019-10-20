import React, { Component } from 'react';

class Cities extends Component {
    constructor(props) {
        super(props);
        this.handleChange = this.handleChange.bind(this);
    };



    handleChange(e) {
        this.props.onCityChange(e.target.value);
    }
    render() {
        const id = this.props.cityId;
        const cities = this.props.cities;
        return (
            <select onChange={this.handleChange} value={id}>
                <option value="0"> Select a city</option>
                {
                    cities.map((city) =>
                        <option key={city.id} value={city.id}>
                            {city.name}
                        </option>
                    )}
            </select>
        );
    }
}

export default Cities