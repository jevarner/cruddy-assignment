import React, { Component } from 'react';
import { Button } from 'reactstrap';

import './Button.css'

export class GetItemMaxCost extends Component {
  static displayName = GetItemMaxCost.name

  constructor(props) {
    super(props);

    this.state = { item: {}, itemName: '', loading: true, loadingMessage: 'Waiting for item...'}

    this.handleChange = this.handleChange.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
  }

  handleChange(event) {
    this.setState({ itemName: event.target.value });
  }

  handleSubmit() {
    this.getMaxPriceByItem()
  }

  static renderItemMaxCostTable(item) {
    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Item Name</th>
            <th>Max Cost</th>
          </tr>
        </thead>
        <tbody>
          <tr>
            <td>{item.itemName}</td>
            <td>{item.cost}</td>
          </tr>
        </tbody>
      </table>
      );
  }

  render() {
    let contents = this.state.loading
    ? <p><em>{this.state.loadingMessage}</em></p>
    : GetItemMaxCost.renderItemMaxCostTable(this.state.item);

    return(
      <div>
        <h2>Task 3: Create a .NET web service endpoint that takes as an input an item name and returns the max price for it</h2>
        <p>This component allows the user to enter an item name and returns the max cost for that item.</p>
        <label>
          Enter item name: 
          <input type="text" value={this.state.itemName} onChange={this.handleChange} />  
        </label>
        <Button className="button-submit" color="primary" onClick={this.handleSubmit}>Submit</Button>
        {contents}
      </div>
    );
  }

  async getMaxPriceByItem() {
    const response = await fetch(`item/${this.state.itemName}`, {method: "GET"});
    const data = await response.json();

    if (data.itemName == null) {
      this.setState({ loadingMessage: 'Invalid item entered, returned nothing...', loading: true})
    }
    else {
      this.setState({ item: data, loading: false });
    }
  }
}