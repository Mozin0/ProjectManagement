import TopBar from "@/components/topBar";
import { Toaster } from "@/components/ui/toaster";
import About from "@/pages/About";
import Home from "@/pages/Home";
import Task from "@/pages/Tasks";
import { Suspense } from "react";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";

const AppRoutes = () => {
  const routes = [
    { path: "/", component: Home },
    { path: "/about", component: About },
    { path: "/:id/tasks", component: Task },
  ];

  return (
    <Router>
      <Toaster />
      <TopBar />
      <Suspense fallback={"Loading..."} />
      <Routes>
        {routes.map(({ path, component: Component }, index) => (
          <Route key={index} path={path} element={<Component />} />
        ))}
        <Route path="*" element={<div>404 - Not Found</div>} />
      </Routes>
    </Router>
  );
};

export default AppRoutes;
