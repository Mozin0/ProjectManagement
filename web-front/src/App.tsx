import { Toaster } from "./components/ui/toaster";
import AppRoutes from "./routes/routes";
import "../css/globals.css";
import { ThemeProvider } from "@/components/themeProvider";

function App() {
  return (
    <>
      <ThemeProvider>
        <AppRoutes />
        <Toaster />
      </ThemeProvider>
    </>
  );
}

export default App;
