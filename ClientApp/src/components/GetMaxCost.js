import React, { Component } from 'react';

export class GetMaxCost extends Component {
  static displayName = GetMaxCost.name;

  constructor(props) {
    super(props);
    this.state = { items: [], loading: true };
  }

  componentDidMount() {
    this.getMaxPrice();
  }

  static renderMaxCostTable(items) {
    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Item Name</th>
            <th>Max Cost</th>
          </tr>
        </thead>
        <tbody>
          {items.map(item =>
            <tr key={item.itemName}>
              <td>{item.itemName}</td>
              <td>{item.cost}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : GetMaxCost.renderMaxCostTable(this.state.items);

    return (
      <div>
        <h2 id="tabelLabel" >Task 2: Create a web service endpoint that returns a list of the max price of each item</h2>
        <p>This component outputs the max price of each item, grouped by their item name.</p>
        {contents}
      </div>
    );
  }

  async getMaxPrice() {
    const response = await fetch('item/', {method: "GET"});
    const data = await response.json();
    this.setState({ items: data, loading: false });
  }
}
