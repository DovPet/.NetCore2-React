import * as React from "react";
import { RouteComponentProps } from "react-router";
import { Link, NavLink } from "react-router-dom";
import { Actor } from "./Actors";
interface ActorFormState {
  title: string;
  loading: boolean;
  actor: Actor;
}
export class ActorForm extends React.Component<
  RouteComponentProps<{}>,
  ActorFormState
> {
  constructor(props) {
    super(props);
    this.state = {
      title: "",
      loading: true,
      actor: new Actor()
    };

    var id = this.props.match.params["id"];
    // This will set state for Edit actor
    if (id > 0) {
      fetch("api/actors/" + id)
        .then(response => response.json() as Promise<Actor>)
        .then(data => {
          this.setState({ title: "Edit", loading: false, actor: data });
        });
    }
    // This will set state for Add actor
    else {
      this.state = {
        title: "Create",
        loading: false,

        actor: new Actor()
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
        <h3>Actor</h3>
        <hr />
        {contents}
      </div>
    );
  }

  // This will handle the submit form event.
  private handleSave(event) {
    event.preventDefault();

    // PUT request for Edit employee.
    if (this.state.actor.id) {
      fetch("api/actors/" + this.state.actor.id, {
        method: "PUT",
        headers: {
          "Content-Type": "application/json",
          Accept: "application/json"
        },
        body: JSON.stringify({
          firstName: event.target.firstName.value,
          lastName: event.target.lastName.value,
          description: event.target.description.value
        })
      })
        .then(response => response.json())
        .then(responseJson => {
          this.props.history.push("/actors");
        });
    }
    // POST request for Add employee.
    else {
      fetch("api/actors", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
          Accept: "application/json"
        },
        body: JSON.stringify({
          firstName: event.target.firstName.value,
          lastName: event.target.lastName.value,
          description: event.target.description.value
        })
      })
        .then(response => response.json())
        .then(responseJson => {
          this.props.history.push("/actors");
        });
    }
  }
  // This will handle Cancel button click event.
  private handleCancel(e) {
    e.preventDefault();
    this.props.history.push("/actors");
  }
  // Returns the HTML Form to the render() method.
  private renderCreateForm() {
    return (
      <form onSubmit={this.handleSave}>
        <div className="form-group row">
          <input type="hidden" name="id" value={this.state.actor.id} />
        </div>

        <div className="form-group row">
          <label className=" control-label col-md-12" htmlFor="firstName">
            First Name
          </label>
          <div className="col-md-4">
            <input
              //ref={nameInput => (this.nameInput = nameInput)}
              className="form-control"
              type="text"
              name="firstName"
              defaultValue={this.state.actor.firstName}
              required
            />
          </div>
        </div>
        <div className="form-group row">
          <label className=" control-label col-md-12" htmlFor="lastName">
            Last Name
          </label>
          <div className="col-md-4">
            <input
              //ref={nameInput => (this.nameInput = nameInput)}
              className="form-control"
              type="text"
              name="lastName"
              defaultValue={this.state.actor.lastName}
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
              defaultValue={this.state.actor.description}
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
