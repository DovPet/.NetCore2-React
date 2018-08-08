import * as React from "react";
import { RouteComponentProps } from "react-router";
import { Link, NavLink } from "react-router-dom";
import { Genre } from "./Genres";
import TextField from "@material-ui/core/TextField";
interface GenreFormState {
  title: string;
  loading: boolean;
  genre: Genre;
}
export class GenreForm extends React.Component<
  RouteComponentProps<{}>,
  GenreFormState
> {
  constructor(props) {
    super(props);
    this.state = {
      title: "",
      loading: true,
      genre: new Genre()
    };

    var id = this.props.match.params["id"];
    // This will set state for Edit genre
    if (id > 0) {
      fetch("api/genres/" + id)
        .then(response => response.json() as Promise<Genre>)
        .then(data => {
          this.setState({ title: "Edit", loading: false, genre: data });
        });
    }
    // This will set state for Add genre
    else {
      this.state = {
        title: "Create",
        loading: false,

        genre: new Genre()
      };
    }
    // This binding is necessary to make "this" work in the callback
    this.handleSave = this.handleSave.bind(this);
    this.handleCancel = this.handleCancel.bind(this);
  }
  public render() {
    let contents = this.state.loading ? (
      <p>
        <em>Loading...</em>
      </p>
    ) : (
      this.renderCreateForm()
    );
    return (
      <div>
        <h1>{this.state.title}</h1>
        <h3>Genre</h3>
        <hr />
        {contents}
      </div>
    );
  }

  // This will handle the submit form event.
  private handleSave(event) {
    event.preventDefault();

    // PUT request for Edit employee.
    if (this.state.genre.id) {
      fetch("api/genres/" + this.state.genre.id, {
        method: "PUT",
        headers: {
          "Content-Type": "application/json",
          Accept: "application/json"
        },
        body: JSON.stringify({
          name: event.target.name.value,
          description: event.target.description.value
        })
      })
        .then(response => response.json())
        .then(responseJson => {
          this.props.history.push("/genres");
        });
    }
    // POST request for Add employee.
    else {
      fetch("api/genres", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
          Accept: "application/json"
        },
        body: JSON.stringify({
          name: event.target.name.value,
          description: event.target.description.value
        })
      })
        .then(response => response.json())
        .then(responseJson => {
          this.props.history.push("/genres");
        });
    }
  }
  // This will handle Cancel button click event.
  private handleCancel(e) {
    e.preventDefault();
    this.props.history.push("/genres");
  }
  // Returns the HTML Form to the render() method.
  private renderCreateForm() {
    return (
      <form onSubmit={this.handleSave}>
        <div className="form-group row">
          <input type="hidden" name="id" value={this.state.genre.id} />
        </div>
        <TextField
          id="name"
          label="Name"
          className={"form-control"}
          value={this.state.genre.name}
          margin="normal"
        />
        <div className="form-group row">
          <label className=" control-label col-md-12" htmlFor="name">
            Name
          </label>
          <div className="col-md-4">
            <input
              //ref={nameInput => (this.nameInput = nameInput)}
              className="form-control"
              type="text"
              name="name"
              defaultValue={this.state.genre.name}
              required
            />
          </div>
        </div>
        <div className="form-group row">
          <label className="control-label col-md-12" htmlFor="description">
            Description
          </label>
          <div className="col-md-4">
            <textarea
              className="form-control"
              name="description"
              style={{ height: 150, width: 500 }}
              defaultValue={this.state.genre.description}
              required
            />
          </div>
        </div>
        <div className="form-group">
          <button type="submit" className="btn btn-default">
            Save
          </button>
          <button className="btn" onClick={this.handleCancel}>
            Cancel
          </button>
        </div>
      </form>
    );
  }
}
