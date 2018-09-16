import React, { Component } from 'react';
import Moment from 'react-moment';

class Presidents extends Component {
    constructor() {
        super();

        this.state = {
            orderNameOption: "ASC",
            data: []
        };
        this.handleOrderInput = this.handleOrderInput.bind(this);
    }

    componentDidMount() {
        this.loadData();
    }

    handleOrderInput(e) {
        const { value, name } = e.target;
        this.setState({
            orderNameOption: value
        }, this.loadData);
        console.log(this.state.orderNameOption)

    }

    loadData() {
        fetch(`https://presidents-corcoran.azurewebsites.net/api/presidents?order=${this.state.orderNameOption}`)
            .then(res => res.json())
            .then(data => this.setState({ data }))
    }

    render() {
        const { data } = this.state;
        return (
            <div>
                <div className="card">
                    <div className="card-body">
                        <br />
                        <div className="row">
                            <div className="col-sm-1">
                                Order:
                            </div>
                            <div className="col-sm-3">
                                <div className="btn-group btn-group-toggle" data-toggle="buttons">
                                    <label className={"btn btn-info " + (this.state.orderNameOption === "ASC" ? "active" : "")}>
                                        <input type="radio" value="ASC" name="order" checked={this.state.orderNameOption === "ASC"} onChange={this.handleOrderInput} /> Ascending  </label>
                                    <label className={"btn btn-info " + (this.state.orderNameOption === "DESC" ? "active" : "")}>
                                        <input type="radio" value="DESC" name="order" checked={this.state.orderNameOption === "DESC"} onChange={this.handleOrderInput} /> Descending  </label>
                                </div>
                            </div>
                            <div className="col-sm-8 align-right">
                                Showing <strong>{data.length}</strong> presidents, order by <i>Name</i> {this.state.orderNameOption}
                            </div>
                        </div>
                        <br />
                        <table className="table striped">
                            <thead>
                                <tr>
                                    <th>President</th>
                                    <th>Birth Day</th>
                                    <th>Birth Place</th>
                                    <th>Death Day</th>
                                    <th>Death Place</th>
                                </tr>
                            </thead>
                            <tbody>
                                {
                                    data.map((president, index) => (
                                        <tr key={index}>
                                            <td>{president.name}</td>
                                            <td><Moment format="MM-DD-YYYY">{president.birthDate}</Moment></td>
                                            <td>{president.birthPlace}</td>
                                            <td>
                                                {president.deathDate ? <Moment format="MM-DD-YYYY">{president.deathDate}</Moment> : "--"}
                                            </td>
                                            <td>{president.deathPlace || "--"}</td>
                                        </tr>
                                    ))
                                }
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>);
    }
}

export default Presidents;