import React, { Component } from 'react';
import { FormGroup, Form, Col, Input, Label, InputGroup, InputGroupAddon, Button } from 'reactstrap';

export class SearchMenu extends Component {
  static displayName = SearchMenu.name

  constructor(props) {
    super(props);

    this.state = { item: {}, loading: true, searchPlaceholder: "Search by " }
  };

  componentDidMount() {
    //this.setState({ searchPlaceholder: `${this.searchPlaceholder} ${this.props.searchType}`})
  }
  
  renderInputByType() {
    const type = this.props.searchType;

    return(
      <Label>
        <Input
          type="radio"
          name="radioId"
          onChange={}
        />{' '}
        {type}
      </Label>
    );
  }

  renderSearchBarByType() {
    const type = this.props.searchType
  }

  render() {
    let contents = this.state.loading
    ? <p><em>Select search type to load grid...</em></p>
    : SearchMenu.renderInputByType()


    return(
      <div>
        <h2>Search for an item by id, name or cost</h2>
        <InputGroup>
          <Input 
            type="search"
            name="search"
            id="idSearch"
            placeholder="ex: 1, 2, 3"
          />
          <InputGroupAddon addonType="append">
            <Button>
              Submit
            </Button>
          </InputGroupAddon>
        </InputGroup>
      </div>
    );
  }
}