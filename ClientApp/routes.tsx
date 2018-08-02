import * as React from "react";
import { Route } from "react-router-dom";
import { Layout } from "./components/Layout";
import { Home } from "./components/Home";
import { FetchData } from "./components/FetchData";
import { Counter } from "./components/Counter";
import { Genres } from "./components/Genres";
import { GenreForm } from "./components/GenreForm";

export const routes = (
  <Layout>
    <Route exact path="/" component={Home} />
    <Route path="/counter" component={Counter} />
    <Route path="/fetchdata" component={FetchData} />

    <Route path="/genres" component={Genres} />
    <Route path="/genre/new" component={GenreForm} />
    <Route path="/genre/edit/:id" component={GenreForm} />
  </Layout>
);
