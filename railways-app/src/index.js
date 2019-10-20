import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import Cities from './cities';


class Search extends React.Component {
    constructor(){
        super();
        this.state = {
            arrivalCity: 0,
            departureCity: 0,
            departureDateTime: Date.UTC
        }
    }
    render() {
        return (
            <div className="search">
                <Search/>
            </div>
        );
    }
}

// ========================================

ReactDOM.render(
    <Search />,
    document.getElementById('root')
);