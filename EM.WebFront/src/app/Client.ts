export class Client {
    Name: string;
    Plugin: Plugin;
    Properties: Properties;
    Schedule: Schedule;

    constructor() {
        this.Plugin = new Plugin();
        this.Properties = new Properties();
        this.Schedule = new Schedule();
    }

    public toString = () : string => {

        return `Client (Name: ${this.Name}, Description: ${this.Properties.Description})`;
    }
}

export class Schedule {
    IsRunContinuously: boolean;
    RunEverySeconds: number;
}

export class Properties {
    IsEnabled: boolean;
    Description: string;
}

export class Runtime {
    LastRun: Date;
    LastLifeSign: Date;
    NextRun: Date;
}

export class Plugin {
    Name: string;
}
